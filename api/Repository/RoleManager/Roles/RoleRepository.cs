using api.Data;
using api.DTO;
using api.DTO.ActivityLog;
using api.DTO.Role;
using api.Helpers;
using api.Helpers.ActivityLog;
using api.Helpers.Enum;
using api.Helpers.Filter;
using api.Models.Roles;
using MathNet.Numerics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using static api.Helpers.AuthenticatedHelper;

namespace api.Repository.RoleManager.Roles
{
    public class RoleRepository : IRoleRepository
    {
        public readonly RmsDbContext _context;

        //the httpcontext accessor is uesed to access req,res outside of a controller -> can provide headers,cookies,session data and user claims
        private IHttpContextAccessor _httpContextAccessor;
        private readonly AuthenticatedUser _authUser;

        public RoleRepository(RmsDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _authUser = _httpContextAccessor.HttpContext.Items["authenticatedUser"] as AuthenticatedUser;
        }

        public async Task<Result<RoleDto>> CreateRoleAsync(RoleDto role, long userId)
        {
            try
            {
                var roleExists = await _context.Roles.FirstOrDefaultAsync(r => r.Name.ToLower() == role.Name.ToLower());

                if (roleExists != null && roleExists.IsDeleted == true)
                {
                    roleExists.IsDeleted = false;
                    roleExists.UpdatedBy = userId;
                    roleExists.UpdatedAt = DateTime.Now;
                    _context.Roles.Update(roleExists);
                    await _context.SaveChangesAsync();

                    return Result<RoleDto>.Success(System.Net.HttpStatusCode.Created, new RoleDto
                    {
                        Id = roleExists.Id,
                        Name = roleExists.Name
                    }, "Role has been restored successfully");
                }

                var newRole = new Role
                {
                    Id = role.Id,
                    Name = role.Name,
                    Slug = role.Name.ToLower().Replace(" ", "_"),
                    DisplayName = role.DisplayName,
                    Status = role.Status,
                    CreatedBy = userId,
                    CreatedAt = DateTime.Now
                };

                ActivityLogHelper.AddActivityLog(new ActivityLogDto
                {
                    //we are passing in create to the GetEnumMemberValue
                    ActivityType = Helpers.Enum.Constants.GetEnumMemberValue(Helpers.Enum.Constants.ActivityType.Create),
                    Description = _authUser.Name + " created role " + role.Name,
                }, _context, _httpContextAccessor);

                await _context.Roles.AddAsync(newRole);
                await _context.SaveChangesAsync();

                var response = new RoleDto
                {
                    Id = newRole.Id,
                    Name = newRole.Name,
                    DisplayName = newRole.DisplayName,
                    Slug = newRole.Slug,
                    Status = newRole.Status,
                    IsDeleted = newRole.IsDeleted,
                    Description = newRole.Description,
                    CreatedBy = newRole.CreatedBy,
                    CreatedAt = newRole.CreatedAt
                };

                return Result<RoleDto>.Success(System.Net.HttpStatusCode.OK, response, "Role Created Successfully");
            }

            catch(Exception ex)
            {
                if(ex.InnerException?.Message.Contains("duplicate") == true)
                {
                    return Result<RoleDto>.Failed(System.Net.HttpStatusCode.BadRequest, ex.StackTrace, ex.InnerException?.Message, "Role already exists");
                }
                return Result<RoleDto>.Failed(System.Net.HttpStatusCode.InternalServerError, ex.StackTrace ?? "no stack trace", ex.Message ?? "No message", "an error occured processing your request");
            }
        }

        public async Task<Result<RoleDto>> DeleteRoleAsync(int id)
        {
            try
            {
                var role = await _context.Roles
                    .Where(r => r.IsDeleted != true)
                    .Include(ur => ur.UserRoles)
                    .FirstOrDefaultAsync(r => r.Id == id);

                if(role == null)
                {
                    return Result<RoleDto>.Failed(System.Net.HttpStatusCode.NotFound, null, null, "role not found");
                }

                //check if role exists in user
                if (role.UserRoles.Count != 0)
                {
                    return Result<RoleDto>.Failed(System.Net.HttpStatusCode.BadRequest, "not allowed", null, "role is assigned to user");
                }

                role.IsDeleted = true;
                role.DeletedAt = DateTime.Now;
                _context.Roles.Update(role);

                ActivityLogHelper.AddActivityLog(new ActivityLogDto
                {
                    ActivityType = Helpers.Enum.Constants.GetEnumMemberValue(Helpers.Enum.Constants.ActivityType.Delete),
                    Description = _authUser.Name + "deleted role" + role.Name,
                }, _context, _httpContextAccessor);

                //revoke all permissions
                var permissions = await _context.RolePermissions.Where(rp => rp.RoleId == id).ToListAsync();
                _context.RolePermissions.RemoveRange(permissions);
                await _context.SaveChangesAsync();

                return Result<RoleDto>.Success(System.Net.HttpStatusCode.OK, null, "Role deleted Successfully");
            }

            catch(Exception ex)
            {
                return Result<RoleDto>.Failed(System.Net.HttpStatusCode.InternalServerError, ex.Message, "there was an error proocessing your request");
            }
        }

        public async Task<Result<RoleDto>> GetRoleByIdAsync(int id)
        {
            try
            {
                var role = await GetRoleAsync(r => r.Id == id);
                if (role == null)
                {
                    return Result<RoleDto>.Failed(System.Net.HttpStatusCode.NotFound, null, null, "Role not found");
                }

                var result = MapRoleDto(role);

                return Result<RoleDto>.Success(System.Net.HttpStatusCode.OK, result);
            }

            catch (Exception ex)
            {
                return Result<RoleDto>.Failed(
                    System.Net.HttpStatusCode.InternalServerError, ex.Message, "An error occured processing your request");
            }
        }

        public RoleDto MapRoleDto(Role role)
        {
            return new RoleDto
            {
                Id = role.Id,
                Name = role.Name,
                DisplayName = role.DisplayName,
                Slug = role.Slug,
                Status = role.Status,
                IsDeleted = role.IsDeleted,
                Description = role.Description,
                CreatedBy = role.CreatedBy,
                CreatedAt = role.CreatedAt,
                Creator = role.Creator != null ? new CreatorDto
                {
                    CreatedBy = role.CreatedBy,
                    FullName = role.Creator.FirstName + " " + role.Creator.LastName,
                    Email = role.Creator.Email
                } : null,
                Permissions = [.. role.Permissions.Select
                (p => new PermissionDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Slug = p.Slug,
                    Description = p.Description,
                    Status = p.Status
                })]
            };
        }

        public async Task<Role> GetRoleAsync(Expression<Func<Role, bool>> predicate)
        {
            return await _context.Roles
                .Include(rP => rP.Permissions)
                .Include(rC => rC.Creator)
                .AsNoTracking()
                .FirstOrDefaultAsync(predicate);
        }

        public async Task<Result<RoleDto>> GetRoleBySlugAsync(string slug)
        {
            try
            {
                var role = await GetRoleAsync(r => r.Slug == slug.ToLower());

                if(role == null)
                {
                    return Result<RoleDto>.Failed(System.Net.HttpStatusCode.NotFound, null, "slug not found");
                }

                var result = MapRoleDto(role);
                return Result<RoleDto>.Success(System.Net.HttpStatusCode.OK, result, "role succesfully retrieved using slug");
            }

            catch(Exception ex)
            {
                return Result<RoleDto>.Failed(System.Net.HttpStatusCode.InternalServerError, null, "there was an error processing your request");
            }
        }

        public async Task<PagedResult<List<RoleDto>>> GetRolesAsync(PaginationFilter filter)
        {
            try
            {
                var query = _context.Roles
                    .Where(r => r.IsDeleted != true)
                    .Include(rP => rP.Permissions)
                    .Include(rC => rC.Creator)
                    .AsNoTracking()
                    .AsQueryable();

                var pagedData = await query.Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize)
                    .ToListAsync();

                int totalRecords = await query.CountAsync();

                var result = pagedData.Select(role => new RoleDto
                {
                    Id = role.Id,
                    Name = role.Name,
                    DisplayName = role.DisplayName,
                    Slug = role.Slug,
                    Status = role.Status,
                    IsDeleted = role.IsDeleted,
                    Description = role.Description,
                    CreatedBy = role.CreatedBy,
                    CreatedAt = role.CreatedAt,

                    Creator = role.Creator != null ? new CreatorDto
                    {
                        CreatedBy = role.CreatedBy,
                        FullName = role.Creator.FirstName + " " + role.Creator.LastName,
                        Email = role.Creator.Email
                    } : null,

                    Permissions = [.. role.Permissions
                        .Select( p => new PermissionDto
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Slug = p.Slug,
                            Description = p.Description,
                            Status = p.Status
                        })]
                }).ToList();

                return PagedResult<List<RoleDto>>
                    .Success(System.Net.HttpStatusCode.OK, result, filter.PageNumber, filter.PageSize, totalRecords, null,
                        "You have successfully retrieved roles");

            }

            catch (Exception ex)
            {
                var trace = filter.Trace
                    ? $"\nStackTrace: {ex.StackTrace}\nInnerException: {ex.InnerException?.Message ?? "None"}:" 
                    : string.Empty;

                return PagedResult<List<RoleDto>>.Failed(System.Net.HttpStatusCode.InternalServerError, "An error occured while processing you request", trace);
            }
        }

        public async Task<bool> HasRole(string role, long userId)
        {
            // check if user has the given role
            var userRole = await _context.UserRoles
                .Include(r => r.Role)
                .Where(ur => ur.UserId == userId && ur.Role.Slug == role && ur.IsDeleted != 1)
                .ToListAsync();

            return userRole.Count != 0;
        }

        public async Task<Result<RoleDto>> UpdateRoleAsync(RoleDto role, long userId)
        {
            try
            {
                var exisitingRole = await _context.Roles.FindAsync(role.Id);

                if(exisitingRole == null)
                {
                    return Result<RoleDto>.Failed(System.Net.HttpStatusCode.NotFound, null, null, "Role not Found");
                }

                Role rL = new()
                {
                    Name = exisitingRole.Name,
                    DisplayName = exisitingRole.DisplayName,
                    Description = exisitingRole.Description,
                    Status = exisitingRole.Status
                };

                exisitingRole.Name = role.Name;
                exisitingRole.DisplayName = role.DisplayName;
                exisitingRole.Description = role.Description;
                exisitingRole.Status = role.Status;
                exisitingRole.UpdatedBy = userId;
                exisitingRole.UpdatedAt = DateTime.Now;

                var changedFields = ObjectComparer.GetChangedFields(rL, exisitingRole, new List<string> { "Name", "DisplayName", "Description", "Status" });

                if (!string.IsNullOrWhiteSpace(changedFields["oldValue"]) || !string.IsNullOrWhiteSpace(changedFields["newValues"]))
                {
                    ActivityLogHelper.AddActivityLog(new ActivityLogDto
                    {
                        ActivityType = Helpers.Enum.Constants.GetEnumMemberValue(Helpers.Enum.Constants.ActivityType.Update),
                        OldValue = changedFields["oldValue"],
                        NewValue = changedFields["newValue"],
                        Description = _authUser.Name + "updated role" + exisitingRole.Name
                    }, _context, _httpContextAccessor);
                }

                _context.Roles.Update(exisitingRole);
                await _context.SaveChangesAsync();

                return Result<RoleDto>.Success(System.Net.HttpStatusCode.OK, role, "Role Updated Successfully");
            }

            catch (Exception ex)
            {
                return Result<RoleDto>.Failed(System.Net.HttpStatusCode.InternalServerError, ex.Message, "there was an error processing your request");
            }
        }
    }
}
