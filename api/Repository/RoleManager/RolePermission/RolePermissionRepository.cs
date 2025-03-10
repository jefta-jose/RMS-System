using api.Data;
using api.DTO;
using api.DTO.Role;
using api.Helpers.Filter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository.RoleManager.RolePermission
{
    public class RolePermissionRepository : IRolePermissionRepository
    {
        private readonly RmsDbContext _context;

        public RolePermissionRepository(RmsDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<RolePermissionDto>>> BulkAssignPermissionToRoleAsync(List<RolePermissionDto> userRole, long userId)
        {
            try
            {
                //check if role permissions already exist
                var exisitingRolePermissions = await _context.RolePermissions
                    .Where(rP => userRole.Select(x => x.PermissionId)
                        .Contains(rP.PermissionId) && userRole.Select(x => x.RoleId).Contains(rP.RoleId)).ToListAsync();

                //remove from the list
                userRole = userRole.Where(x => !exisitingRolePermissions.Select(rP => rP.PermissionId).Contains(x.PermissionId)).ToList();

                //detach from existing entries -- stop tracking existing ones
                foreach (var existinRolePermission in exisitingRolePermissions)
                {
                    _context.Entry(existinRolePermission).State = EntityState.Detached;
                }

                //add new role permissions
                var newRolePermissions = userRole.Select(rP => new Models.Roles.RolePermission
                {
                    RoleId = rP.RoleId,
                    PermissionId = rP.PermissionId,
                    IsDeleted = false,
                    CreatedBy = userId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                }).ToList();

                await _context.RolePermissions.AddRangeAsync(newRolePermissions);
                await _context.SaveChangesAsync();

                return Result<List<RolePermissionDto>>.Success(System.Net.HttpStatusCode.Created, userRole, "Permissions have been assigned to roles successfully");
            }

            catch (Exception ex)
            {
                return Result<List<RolePermissionDto>>.Failed(System.Net.HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message, "An error occured when processing your request");
            }

        }

        public async Task<Result<List<RolePermissionDto>>> BulkRemovePermissionToRoleAsync(List<RolePermissionDto> rolePermissions, long userId)
        {
            try
            {
                var existingRolePermissions = await _context.RolePermissions
                    .Where(rP => (rP.IsDeleted != null && rP.IsDeleted != true) && rolePermissions.Select(x => x.PermissionId).Contains(rP.PermissionId)
                       && rolePermissions.Select(x => x.RoleId).Contains(rP.RoleId)).ToListAsync();

                if(existingRolePermissions.Count == 0)
                {
                    return Result<List<RolePermissionDto>>.Failed(System.Net.HttpStatusCode.NotFound, null, null, "Role permissions not found");
                }

                //remove range 
                _context.RolePermissions.RemoveRange(existingRolePermissions);
                await _context.SaveChangesAsync();

                return Result<List<RolePermissionDto>>.Success(System.Net.HttpStatusCode.OK, rolePermissions, "Permissions have been revoked from roles successfully");
            }

            catch(Exception ex)
            {
                return Result<List<RolePermissionDto>>.Failed(System.Net.HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message, "An error occured when processing your request");
            }
        }

        public async Task<PagedResult<List<RolePermissionDto>>> GetRolePermissionsAsync(int roleId, PaginationFilter filter)
        {
            try
            {
                var validFilters = new PaginationFilter(filter.PageNumber, filter.PageSize);

                var rolePermissions = await _context.RolePermissions
                    .Where(rP => rP.RoleId == roleId && rP.IsDeleted != true)
                        .Include(x => x.Permission)
                        .Skip((validFilters.PageNumber - 1) * validFilters.PageSize)
                        .Take(validFilters.PageSize)
                        .ToListAsync();

                var totalRecords = await _context.RolePermissions
                    .CountAsync(rP => rP.RoleId == roleId && rP.IsDeleted != true);

                var pagedData = rolePermissions.Select(rP => new RolePermissionDto
                {
                    RoleId = rP.RoleId,
                    PermissionId = rP.PermissionId,
                    Status = rP.Status,
                    CreatedBy = rP.CreatedBy,
                    Permission = new PermissionDto
                    {
                        Name = rP.Permission.Name,
                        DisplayName = rP.Permission.DisplayName,
                        Slug = rP.Permission.Slug,
                        Description = rP.Permission.Description,
                        CreatedBy = rP.Permission.CreatedBy
                    },
                    Creator = _context.Users.FindAsync(rP.CreatedBy).Result != null ? new CreatorDto()
                    {
                        CreatedBy = rP.CreatedBy,
                    } : null,
                }).ToList();

                return PagedResult<List<RolePermissionDto>>.Success(System.Net.HttpStatusCode.OK, pagedData, validFilters.PageNumber, validFilters.PageSize, totalRecords, null,
                    "You have Successfully retrieved role permsissions");
            }

            catch (Exception ex)
            {
                return PagedResult<List<RolePermissionDto>>.Failed(System.Net.HttpStatusCode.InternalServerError, ex.Message, ex.InnerException?.Message,
                    "An error occured while processing your request");
            }
        }
    }
}
