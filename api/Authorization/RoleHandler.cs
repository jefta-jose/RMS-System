namespace api.Authorization
{
    public static class RmsAuthorizationPolicies
    {
        //policy for checking if user has a minimum of Admin role
        public const string AdminUserRolePolicy = "AdminUserRolePolicy";

        //policy for checking is user has a minimum of SuperAdmin role
        public const string SuperAdminRolePolicy = "SuperAdminRolePolicy";
    }
}
