using api.Data;
using api.Models.Roles;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class AuthenticatedHelper
    {
        public class AuthenticatedUser
        {
            public long ID { get; set; }
            public string Email { get; set; }
            public string Name { get; set; }
            public long RoleId { get; set; }
            public Role Role { get; set; }
            public IEnumerable<long> AllowedLocations { get; set; }
            public bool IsSDL { get; set; }
        }

        public static class AuthencticationHelper
        {
            public static async Task<AuthenticatedUser> GetAuthenticatedUser(RmsDbContext dbContext, ClaimsPrincipal user)
            {
                string authenticatedUserEmail = user.FindFirst(ClaimTypes.Email)?.Value;
                AuthenticatedUser authenticatedUser = await dbContext.Users
                    .Include(uR => uR.UserRole)
                        .ThenInclude(r => r.Role)
                            .ThenInclude(rP => rP.Permissions)
                    .Select(aU => new AuthenticatedUser
                    {
                        ID = aU.ID,
                        Name = aU.FullName,
                        Email = aU.Email,
                        RoleId = aU.UserRoleID,
                        Role = new Role
                        {
                            Name = aU.UserRole.Role.Name,
                            Permissions = aU.UserRole.Role.Permissions
                        },
                        IsSDL = aU.IsSDL,
                        AllowedLocations = aU.UserSolutionDeliveryLeaders.Select(sdl => sdl.SolutionDeliveryLeaderID)
                    }).FirstOrDefaultAsync(u => u.Email == authenticatedUserEmail);

                return authenticatedUser;
            }
        }
    }
}
