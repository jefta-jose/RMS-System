using api.Models.ActivityLog;
using api.Models.Email;
using api.Models.Navbar;
using api.Models.Roles;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class RmsDbContext : DbContext
    {
        public RmsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected RmsDbContext()
        {
        }

        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ResourceLevel> ResourceLevels { get; set; }
        public virtual DbSet<ResourceType> ResourceTypes { get; set; }
        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }
        public virtual DbSet<EarningType> EarningTypes { get; set; }
        public virtual DbSet<ResourceLocation> ResourceLocations { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<BusinessUnit> BusinessUnits { get; set; }
        public virtual DbSet<SolutionDeliveryLeader> SolutionDeliveryLeaders { get; set; }
        public virtual DbSet<ProjectResourceType> ProjectResourceTypes { get; set; }
        public virtual DbSet<ProjectResource> ProjectResources { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<UserLocation> UserLocations { get; set; }
        public virtual DbSet<UserSolutionDeliveryLeader> UserSolutionDeliveryLeaders { get; set; }
        public virtual DbSet<StatusGroup> StatusGroups { get; set; }
        public virtual DbSet<UserRoleLocation> UserRoleLocations { get; set; }
        public virtual DbSet<UserRoleSolutionDeliveryLeader> UserRoleSolutionDeliveryLeaders { get; set; }
        public virtual DbSet<UserPreference> UserPreferences { get; set; }
        public virtual DbSet<Allocation> Allocations { get; set; }
        public virtual DbSet<IntacctTimesheet> IntacctTimesheets { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<CustomerSdl> CustomerSdls { get; set; }
        public virtual DbSet<ActivityLog> ActivityLogs { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<ProjectHealth> ProjectHealth { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<EmailConfiguration> EmailConfigurations { get; set; }
        public virtual DbSet<NavbarMenu> NavbarMenus { get; set; }
    }
}
