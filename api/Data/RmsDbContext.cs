using api.Models.ActivityLog;
using api.Models.Email;
using api.Models.Navbar;
using api.Models.Roles;
using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data.EntityConfigs.Customer;
using api.Data.EntityConfigs.Email;
using api.Data.EntityConfigs.Intacct;
using api.Data.EntityConfigs.NavbarMenu;
using api.Data.EntityConfigs.ProjectHealthConfig;
using api.Data.EntityConfigs.Role;
using api.Data.EntityConfigs;
using api.EF.EntityConfigs;
using System;

namespace api.Data
{
    public class RmsDbContext : DbContext
    {
        public RmsDbContext(DbContextOptions options) : base(options)
        {}
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new ResourceConfig());
            modelBuilder.ApplyConfiguration(new LocationConfig());
            modelBuilder.ApplyConfiguration(new ProjectConfig());
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new ProjectResourceTypeConfig());
            modelBuilder.ApplyConfiguration(new ResourceTypeConfig());
            modelBuilder.ApplyConfiguration(new EmployeeTypeConfig());
            modelBuilder.ApplyConfiguration(new EarningTypeConfig());
            modelBuilder.ApplyConfiguration(new ResourceLocationConfig());
            modelBuilder.ApplyConfiguration(new ProjectResourceConfig());
            modelBuilder.ApplyConfiguration(new StatusGroupConfig());
            modelBuilder.ApplyConfiguration(new StatusConfig());
            modelBuilder.ApplyConfiguration(new UserLocationConfig());
            modelBuilder.ApplyConfiguration(new UserSolutionDeliveryLeaderConfig());
            modelBuilder.ApplyConfiguration(new UserRoleConfig());
            modelBuilder.ApplyConfiguration(new UserRoleLocationConfig());
            modelBuilder.ApplyConfiguration(new UserRoleSolutionDeliveryLeaderConfig());
            modelBuilder.ApplyConfiguration(new UserPreferenceConfig());
            modelBuilder.ApplyConfiguration(new AllocationConfig());
            modelBuilder.ApplyConfiguration(new SolutionDeliveryLeaderConfig());
            modelBuilder.ApplyConfiguration(new IntacctTimesheetConfig());
            modelBuilder.ApplyConfiguration(new TempalteConfig());
            modelBuilder.ApplyConfiguration(new CustomerSdlConfig());
            modelBuilder.ApplyConfiguration(new ActivityLogConfig());
            modelBuilder.ApplyConfiguration(new RefreshTokenConfig());
            modelBuilder.ApplyConfiguration(new ProjectHealthConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new RolePermissionConfig());
            modelBuilder.ApplyConfiguration(new PermissionConfig());
            modelBuilder.ApplyConfiguration(new EmailConfigurationConfig());
            modelBuilder.ApplyConfiguration(new NavbarMenuConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(Console.WriteLine);
    }
}