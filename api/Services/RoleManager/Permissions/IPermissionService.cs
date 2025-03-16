using api.DTO.Role;
using api.DTO;
using api.Helpers.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Services.RoleManager.Permissions
{
    public interface IPermissionService
    {
        Task<PagedResult<List<PermissionDto>>> GetPermissionsAsync(PaginationFilter filter);
        Task<Result<List<PermissionDto>>> GetAllPermissionsAsync();
        Task<Result<PermissionDto>> GetPermissionByIdAsync(int id);
        Task<Result<PermissionDto>> CreatePermissionAsync(PermissionDto permission);
        Task<Result<PermissionDto>> UpdatePermissionAsync(PermissionDto permission);
        Task<Result<PermissionDto>> DeletePermissionAsync(int id);
        Task<bool> HasPermission(string permission);
    }
}
