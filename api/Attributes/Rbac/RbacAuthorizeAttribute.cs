using Microsoft.AspNetCore.Mvc;

namespace api.Attributes.Rbac;

public class RbacAuthorizeAttribute : TypeFilterAttribute
//TypeFilterAttribute allows attaching dependency-injected filters to controllers
{
    public RbacAuthorizeAttribute(string permission) : base(typeof(RbacAuthorizationFilter))
    //RbacAuthorizeAttribute accepts permission argument ie
    //permission.Create or permission.Read and passes it to thje filter

    //base(typeof(RbacAuthorizationFilter)) → Specifies that RbacAuthorizationFilter will handle the authorization.
    {
        Arguments = new object[] { permission };
        //Arguments = new object[] { permission };
        //→ Passes the permission to RbacAuthorizationFilter, so it can check if the user has the required access.
    }
}