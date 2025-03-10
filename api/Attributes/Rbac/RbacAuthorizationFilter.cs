using Microsoft.AspNetCore.Mvc.Filters;

namespace api.Attributes.Rbac
{
    public interface RbacAuthorizationFilter : IAsyncAuthorizationFilter
    {
        private readonly IRolePermissionService _rolePermissionService;
    }
}
