using api.Data;
using api.DTO;
using api.DTO.Role;
using api.Helpers;
using api.Helpers.ActivityLog;
using api.Helpers.Enum;
using api.Helpers.Filter;
using api.Models.Roles;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static api.Helpers.AuthenticatedHelper;

namespace api.Repository.RoleManager.Permisions
{
    public class PermissionRepository(RmsDbContext context, IMemoryCache cache, AuthenticatedUser authenticatedUser, IHttpContextAccessor httpContextAccessor) : IPermissionRepository
    {
        private readonly RmsDbContext _context = context;
        private readonly IMemoryCache _memoryCache = cache;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly AuthenticatedUser _authUser = authenticatedUser;

        public async Task<Result<PermissionDto>> CreatePermissionAsync(PermissionDto permission, long userId)
        {
            try
            {
                Permission newPermission = new()
                {
                    Id = permission.Id,
                    Name = permission.Name,
                    Group = permission.Group,
                    DisplayName = permission.DisplayName,
                    Slug = permission.Name.ToLower().Replace(" ", "-"),
                    Description = permission.Description,
                    Status = permission.Status,
                    CreatedBy = userId,
                    CreatedAt = DateTime.Now
                };

                ActivityLogHelper.AddActivityLog(new DTO.ActivityLog.ActivityLogDto
                {
                    ActivityType = Constants.GetEnumMemberValue(Constants.ActivityType.Create),
                    Description = _authUser + "created permission" + permission.DisplayName
                },_context, _httpContextAccessor);

                await _context.Permissions.AddAsync(newPermission);
                await _context.SaveChangesAsync();

                return Result<PermissionDto>.Success(System.Net.HttpStatusCode.OK, permission, "you have successfully created a new permission");
            }

            catch(Exception ex)
            {
                return Result<PermissionDto>.Failed(System.Net.HttpStatusCode.OK, ex.Message, "there was a problem processing your request");
            }
        }

        public async Task<Result<PermissionDto>> DeletePermissionAsync(int id)
        {
            try
            {
                var permission = await _context.Permissions.FindAsync(id);

                if(permission == null)
                {
                    return Result<PermissionDto>.Failed(System.Net.HttpStatusCode.NotFound, null, null, "permission not found");
                }

                ActivityLogHelper.AddActivityLog(new DTO.ActivityLog.ActivityLogDto
                {
                    ActivityType = Constants.GetEnumMemberValue(Constants.ActivityType.Delete),
                    Description = _authUser + "deleted persmission" + permission.Name,
                }, _context, _httpContextAccessor);

                _context.Permissions.Remove(permission);
                await _context.SaveChangesAsync();

                return Result<PermissionDto>.Success(System.Net.HttpStatusCode.OK, null, "permission deleted successfully");
            }

            catch(Exception ex)
            {
                return Result<PermissionDto>.Failed(System.Net.HttpStatusCode.InternalServerError, ex.Message, "there was a problem processing your request");
            }
        }

        public async Task<Result<List<PermissionDto>>> GetAllPermissionsAsync()
        {
            var cacheKey = $"PermissionsByRole:{DateTime.Now.Day}";

            if (_memoryCache.TryGetValue(cacheKey, out List<PermissionDto> permissions))
            {
                return Result<List<PermissionDto>>.Success(System.Net.HttpStatusCode.OK, permissions);
            }

            List<PermissionDto> result = await _context.Permissions
                .AsNoTracking()
                .Select(permission => new PermissionDto
                {
                    Id = permission.Id,
                    Name = permission.Name,
                    Group = permission.Group,
                    DisplayName = permission.DisplayName,
                    Status = permission.Status,
                    Slug = permission.Slug,
                    Description = permission.Description
                }).ToListAsync();

            _memoryCache.Set(cacheKey, result, TimeSpan.FromSeconds(30));

            return Result<List<PermissionDto>>.Success(System.Net.HttpStatusCode.OK, result);
        }

        public async Task<Result<PermissionDto>> GetPermissionByIdAsync(int id)
        {
            try
            {
                var permission = await _context.Permissions.FindAsync(id);

                if(permission == null)
                {
                    return Result<PermissionDto>.Failed(System.Net.HttpStatusCode.NotFound, null, null, "Permission not found");
                }

                PermissionDto result = new()
                {
                    Id = permission.Id,
                    Name = permission.Name,
                    Group = permission.Group,
                    DisplayName = permission.DisplayName,
                    Status = permission.Status,
                    Slug = permission.Slug,
                    Description = permission.Description,
                };

                return Result<PermissionDto>.Success(System.Net.HttpStatusCode.OK, result, "results found successfully");
            }

            catch(Exception ex)
            {
                return Result<PermissionDto>.Failed(System.Net.HttpStatusCode.InternalServerError, ex.Message, "There was an error processing your request");
            }
        }

        public async Task<PagedResult<List<PermissionDto>>> GetPermissionsAsync(PaginationFilter filter)
        {
            try
            {
                var query = _context.Permissions.AsQueryable();

                var pagedData = await query.AsNoTracking().Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize)
                    .ToListAsync();

                var totalRecords = await query.CountAsync();

                var result = pagedData.Select(permission => new PermissionDto
                {
                    Id = permission.Id,
                    Name = permission.Name,
                    Group = permission.Group,
                    DisplayName = permission.DisplayName,
                    Status = permission.Status,
                    Slug = permission.Slug,
                    Description = permission.Description,
                }).ToList();

                return PagedResult<List<PermissionDto>>.Success(System.Net.HttpStatusCode.OK, result, filter.PageNumber, filter.PageSize, totalRecords, "you have successfully retrieved permissions");

            }

            catch(Exception ex)
            {
                {
                    var trace = filter.Trace
                        ? $"\nStackTrace: {ex.StackTrace}\nInnerException: {ex.InnerException?.Message ?? "None"}"
                        : string.Empty;

                    return PagedResult<List<PermissionDto>>.Failed(System.Net.HttpStatusCode.InternalServerError, "An error occured while processing you request", trace);
                }
            }
        }

        public async Task<bool> HasPermission(string permission, long userId)
        {
            var userRolePermission = await _context.UserRoles
                .Include(r => r.Role)
                .ThenInclude(rp => rp.RolePermissions)
                .ThenInclude(p => p.Permission)
                .Where(ur => ur.UserId == userId && ur.IsDeleted != 1 && ur.Role.RolePermissions.Any(rp => rp.Permission.Slug == permission))
                .ToListAsync();

            return userRolePermission.Count != 0;
        }

        public async Task<Result<PermissionDto>> UpdatePermissionAsync(PermissionDto permission, long userId)
        {
            try
            {
                var existingPermission = await _context.Permissions.FindAsync(permission.Id);

                if(existingPermission == null)
                {
                    return Result<PermissionDto>.Failed(System.Net.HttpStatusCode.NotFound, null, "permssion not found");
                }

                Permission p = new()
                {
                    Name = existingPermission.Name,
                    Status = existingPermission.Status,
                    DisplayName = existingPermission.DisplayName,
                    Group = existingPermission.Group,
                    Description = existingPermission.Description
                };

                existingPermission.Name = permission.Name;
                existingPermission.Group = permission.Group;
                existingPermission.DisplayName = permission.DisplayName;
                existingPermission.Status = permission.Status;
                existingPermission.Description = permission.Description;

                _context.Permissions.Update(existingPermission);

                Dictionary<string, string> changedFields = ObjectComparer.GetChangedFields(p, existingPermission, new List<string> { "Name", "DisplayName", "Description", "Status", "Group" });
                
                if(!string.IsNullOrWhiteSpace(changedFields["oldValue"]) || !string.IsNullOrWhiteSpace(changedFields["newValue"]))
                {
                    ActivityLogHelper.AddActivityLog(new DTO.ActivityLog.ActivityLogDto
                    {
                        ActivityType = Constants.GetEnumMemberValue(Constants.ActivityType.Update),
                        OldValue = changedFields["oldValue"],
                        NewValue = changedFields["newValue"],
                        Description = _authUser + "updated permission" + existingPermission.DisplayName
                    }, _context, _httpContextAccessor);
                }

                await _context.SaveChangesAsync();

                return Result<PermissionDto>.Success(System.Net.HttpStatusCode.OK, permission, "Permission updated successfully");
            }

            catch(Exception ex)
            {
                return Result<PermissionDto>.Failed(System.Net.HttpStatusCode.InternalServerError, ex.Message, "there was a problem processing your request");
            }
        }
    }
}
