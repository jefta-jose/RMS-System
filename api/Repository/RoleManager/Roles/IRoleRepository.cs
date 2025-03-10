using api.DTO;
using api.DTO.Role;
using api.Helpers.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Repository.RoleManager.Roles
{
    public interface IRoleRepository
    {
        Task<PagedResult<List<RoleDto>>> GetRolesAsync(PaginationFilter filter);
        Task<Result<RoleDto>> GetRoleByIdAsync(int id);
        Task<Result<RoleDto>> GetRoleBySlugAsync(string slug);
        Task<Result<RoleDto>> CreateRoleAsync(RoleDto role, long userId);
        Task<Result<RoleDto>> UpdateRoleAsync(RoleDto role, long userId);
        Task<Result<RoleDto>> DeleteRoleAsync(int id);
        Task<bool> HasRole(string role, long userId);
    }
}
