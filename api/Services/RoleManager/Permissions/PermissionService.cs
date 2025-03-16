using api.DTO;
using api.DTO.Role;
using api.Helpers.Filter;
using api.Repository.RoleManager.Permisions;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using static api.Helpers.AuthenticatedHelper;

namespace api.Services.RoleManager.Permissions
{
    public class PermissionService(IPermissionRepository permissionRepository, IHttpContextAccessor httpContextAccessor) : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository = permissionRepository;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        // using a property instead of a field
        private AuthenticatedUser _authenticatedUser => _httpContextAccessor.HttpContext?.Items["authenticatedUser"] as AuthenticatedUser;
        //now _authenticatedUser is a computed property instead of a field

        public Task<Result<PermissionDto>> CreatePermissionAsync(PermissionDto permission)
        {
            return _permissionRepository.CreatePermissionAsync(permission, _authenticatedUser.ID);
        }

        public Task<Result<PermissionDto>> DeletePermissionAsync(int id)
        {
            return _permissionRepository.DeletePermissionAsync(id);
        }

        public Task<Result<List<PermissionDto>>> GetAllPermissionsAsync()
        {
            return _permissionRepository.GetAllPermissionsAsync();
        }

        public Task<Result<PermissionDto>> GetPermissionByIdAsync(int id)
        {
            return _permissionRepository.GetPermissionByIdAsync(id);
        }

        public Task<PagedResult<List<PermissionDto>>> GetPermissionsAsync(PaginationFilter filter)
        {
            return _permissionRepository.GetPermissionsAsync(filter);
        }

        public Task<bool> HasPermission(string permission)
        {
            return _permissionRepository.HasPermission(permission, _authenticatedUser.ID);
        }

        public Task<Result<PermissionDto>> UpdatePermissionAsync(PermissionDto permission)
        {
            return _permissionRepository.UpdatePermissionAsync(permission, _authenticatedUser.ID);
        }
    }
}
