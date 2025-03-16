using api.Services.RoleManager.RolePermission;
using api.Services.RoleManager.Roles;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;
using static api.Helpers.AuthenticatedHelper;

namespace api.Attributes.Rbac
{
    public class RbacAuthorizationFilter(IRolePermissionService permissionService, IRoleService roleService) : IAsyncAuthorizationFilter
    {
        private readonly IRolePermissionService _rolePermissionService = permissionService;
        private readonly IRoleService _roleService = roleService;
        private readonly string _permission;

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            //the schemas url is a predefined claim type used to store the role of a user.
            //context.Httpcontext.User.Claims -> retrieves all claims attached to the authenticated user
            //FirstOrDefault() -> finds the first claim where the type is the schema url
            var roleClaim = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");
            
            if(roleClaim != null)
            {
                var hasRole = await _roleService.HasRole(roleClaim.Value);

                bool permissionFound = false;

                if (hasRole)
                {
                    var role = await _roleService.GetRoleBySlugAsync(roleClaim.Value);

                    if(role != null)
                    {
                        permissionFound = role.Value.Permissions.Any(p => p.Slug == _permission);
                    }
                }

                if (!permissionFound)
                {
                    context.Result = new JsonForbidResult();
                }
            }
            else
            {
                context.Result = new JsonForbidResult();
            }
        }
    }
}
