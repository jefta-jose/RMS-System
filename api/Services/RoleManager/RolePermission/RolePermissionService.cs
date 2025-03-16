using api.DTO;
using api.DTO.Role;
using api.Helpers.Filter;
using api.Repository.RoleManager.RolePermission;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using static api.Helpers.AuthenticatedHelper;

namespace api.Services.RoleManager.RolePermission
{
    public class RolePermissionService(IRolePermissionRepository repository, IHttpContextAccessor httpContextAccessor) : IRolePermissionService
    {
        private readonly IRolePermissionRepository _repository = repository;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        private AuthenticatedUser _authenticateUser => _httpContextAccessor.HttpContext?.Items["authenticatedUser"] as AuthenticatedUser;
        public async Task<Result<List<RolePermissionDto>>> BulkAssignPermissionToRoleAsync(List<RolePermissionDto> rolePermissions)
        {
            return await _repository.BulkAssignPermissionToRoleAsync(rolePermissions, _authenticateUser.ID);
        }

        public async Task<Result<List<RolePermissionDto>>> BulkRemovePermissionFromRoleAsync(List<RolePermissionDto> rolePermissions)
        {
            return await _repository.BulkRemovePermissionToRoleAsync(rolePermissions, _authenticateUser.ID);
        }

        public async Task<PagedResult<List<RolePermissionDto>>> GetRolePermissionsAsync(int roleId, PaginationFilter filter)
        {
            return await _repository.GetRolePermissionsAsync(roleId, filter);
        }
    }
}
