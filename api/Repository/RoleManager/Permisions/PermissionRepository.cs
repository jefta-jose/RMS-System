using api.Data;
using api.DTO;
using api.DTO.Role;
using api.Helpers.ActivityLog;
using api.Helpers.Enum;
using api.Helpers.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public Task<Result<PermissionDto>> CreatePermissionAsync(PermissionDto permission)
        {
            throw new System.NotImplementedException();
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

                return Result<PermissionDto>.Success(System.Net.HttpStatusCode.OK, null, "permission deleted successfully";
            }

            catch(Exception ex)
            {
                return Result<PermissionDto>.Failed(System.Net.HttpStatusCode.InternalServerError, ex.Message, "there was a problem processing your request");
            }
        }

        public Task<Result<List<PermissionDto>>> GetAllPermissionsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Result<PermissionDto>> GetPermissionByIdAsync(int id)
        {
            throw new System.NotImplementedException();
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

        public Task<Result<PermissionDto>> UpdatePermissionAsync(PermissionDto permission)
        {
            throw new System.NotImplementedException();
        }
    }
}
