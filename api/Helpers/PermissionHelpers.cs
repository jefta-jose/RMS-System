using System.Linq;
using static api.Helpers.AuthenticatedHelper;

namespace api.Helpers
{
    public static class PermissionHelpers
    {
        public static IQueryable<T> ApplyLocationFilter<T>(IQueryable<T> query, AuthenticatedUser authUser)
        {
            return query;
        }
    }
}
