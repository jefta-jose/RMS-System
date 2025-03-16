using api.DTO.Role;
using api.DTO;
using api.Helpers.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Services.RoleManager.RolePermission
{
    public interface IRolePermissionService
    {
        Task<Result<List<RolePermissionDto>>> BulkAssignPermissionToRoleAsync(List<RolePermissionDto> rolePermissions);
        //bulk remove permission from role
        Task<Result<List<RolePermissionDto>>> BulkRemovePermissionFromRoleAsync(List<RolePermissionDto> rolePermissions);
        //get all permissions of a role
        Task<PagedResult<List<RolePermissionDto>>> GetRolePermissionsAsync(int roleId, PaginationFilter filter);
    }
}
