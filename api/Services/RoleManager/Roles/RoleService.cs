using api.DTO;
using api.DTO.Role;
using api.Helpers.Filter;
using api.Repository.RoleManager.Roles;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using static api.Helpers.AuthenticatedHelper;

namespace api.Services.RoleManager.Roles
{
    public class RoleService(IRoleRepository roleRepository, IHttpContextAccessor httpContextAccessor) : IRoleService
    {
        private readonly IRoleRepository _roleRepository = roleRepository;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        private AuthenticatedUser _authenticatedUser => _httpContextAccessor.HttpContext?.Items["authenticatedUser"] as AuthenticatedUser;
        public Task<Result<RoleDto>> CreateRoleAsync(RoleDto role)
        {
            return _roleRepository.CreateRoleAsync(role, _authenticatedUser.ID);
        }

        public Task<Result<RoleDto>> DeleteRoleAsync(int id)
        {
            return _roleRepository.DeleteRoleAsync(id);
        }

        public Task<Result<RoleDto>> GetRoleByIdAsync(int id)
        {
            return _roleRepository.GetRoleByIdAsync(id);
        }

        public Task<Result<RoleDto>> GetRoleBySlugAsync(string slug)
        {
            return _roleRepository.GetRoleBySlugAsync(slug);
        }

        public Task<PagedResult<List<RoleDto>>> GetRolesAsync(PaginationFilter filter)
        {
            return _roleRepository.GetRolesAsync(filter);
        }

        public Task<bool> HasRole(string role)
        {
            return _roleRepository.HasRole(role, _authenticatedUser.ID);
        }

        public Task<Result<RoleDto>> UpdateRoleAsync(RoleDto role)
        {
            return _roleRepository.UpdateRoleAsync(role, _authenticatedUser.ID);
        }
    }
}
