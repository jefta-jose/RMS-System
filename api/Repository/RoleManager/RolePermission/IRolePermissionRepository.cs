using System.Collections.Generic;
using System.Threading.Tasks;
using api.DTO;
using api.DTO.Role;
using api.Helpers.Filter;

namespace api.Repository.RoleManager.RolePermission
{
    public interface IRolePermissionRepository
    {
        Task<Result<List<RolePermissionDto>>> BulkAssignPermissionToRoleAsync(List<RolePermissionDto> rolePermission, long userId);
        Task<Result<List<RolePermissionDto>>> BulkRemovePermissionToRoleAsync(List<RolePermissionDto> rolePermission, long userId);
        Task<PagedResult<List<RolePermissionDto>>> GetRolePermissionsAsync(int roleId, PaginationFilter filter);
    }
}
