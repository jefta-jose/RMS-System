namespace api.Common.Permissions
{
    public class Permission
    {
        //start navbar menus
        public const string ViewNavbarDashboardMenu = "view-navbar-dashboard-menu";
        public const string ViewNavbarProjectsMenu = "view-navbar-projects-menu";
        public const string ViewNavbarContractsMenu = "view-navbar-contracts-menu";
        public const string ViewNavbarResourcesMenu = "view-navbar-resources-menu";
        public const string ViewNavbarReportsMenu = "view-navbar-reports-menu";
        public const string ViewNavbarSettingsMenu = "view-navbar-settings-menu";
        //end Navbar menus

        //BEGIN dashboard
        public const string ViewDashboard = "view-dashboard";
        public const string ViewDashboardChart = "view-dashboard-chart";
        public const string ViewDashboardWeeklyAllocations = "view-dashboard-weekly-allocations";
        public const string ViewDashboardFilters = "view-dashboard-filters";
        public const string ApplyDashboardSdlFilters = "apply-dashboard-sdl-filters";
        public const string ApplyDashboardCustomerFilters = "apply-dashboard-customer-filters";
        public const string ApplyDashboardProjectFilters = "apply-dashboard-project-filters";
        public const string ViewDashboardStaffingNeeds = "view-dashboard-staffing-needs";
        public const string ExportDashboardStaffingNeeds = "export-dashboard-staffing-needs";
        public const string ExportDashboardAllocationReports = "export-dashboard-allocation-reports";
        public const string ViewDashboardSearchbar = "view-dashboard-searchbar";
        public const string ViewDashboardAvailabilityReport = "view-dashboard-availability-report";
        public const string ExportDashboardAvailabilityReport = "export-dashboard-availability-report";
        //END dashboard

        //BEGIN projects
        public const string ViewProjects = "view-projects";
        public const string ViewPartialProjects = "view-partial-projects";
        public const string ViewProjectDetails = "view-project-details";
        public const string ViewProjectAllocations = "view-project-allocations";
        public const string ViewProjectContracts = "view-project-contracts";
        public const string ViewProjectAssignedResources = "view-project-assigned-resources";
        public const string ViewProjectHealth = "view-project-health";
        public const string CreateProject = "create-project";
        public const string CreateProjectResource = "create-project-resource";
        public const string RequestNewProjectResource = "request-new-project-resource";
        public const string EditProject = "edit-project";
        public const string EditProjectAllocations = "edit-project-allocations";
        public const string DeleteProject = "delete-project";
        public const string DeleteProjectAllocations = "delete-project-allocations";
        public const string ImportProjects = "import-projects";
        public const string ExportProjects = "export-projects";
        public const string ExportProjectAsPdf = "export-projects-as-pdf";
        public const string ExportProjectAsExcel = "export-projects-as-excel";
        public const string ExportProjectAsCsv = "export-projects-as-csv";
        public const string ViewProjectFilters = "view-project-filters";
        public const string ApplyProjectFilterBySdl = "apply-project-filter-by-sdl";
        public const string ApplyProjectFilterByProject = "apply-project-filter-by-project";
        public const string ApplyProjectFilterByStatus = "apply-project-filter-by-status";
        //--project resources--
        public const string ViewProjectResources = "view-project-resources";
        public const string ViewProjectResourcesAvailable = "view-project-resources-available";
        public const string AssignProjectResource = "assign-project-resource";
        public const string EditProjectResource = "edit-project-resource";
        public const string DeleteProjectResource = "delete-project-resource";
        //end project
        //BEGIN resources
        public const string ViewResources = "view-resources";
        public const string ViewResourceDetails = "view-resource-details";
        public const string CreateResources = "create-resources";
        public const string ActivateResources = "activate-resources";
        public const string DeactivateResources = "deactivate-resources";
        public const string EditResources = "edit-resources";
        public const string DeleteResources = "delete-resources";
        public const string ImportResources = "import-resources";
        public const string ExportResources = "export-resources";
        public const string ApplyResourceFilters = "apply-resource-filters";
        public const string ApplyResourceFilterBySdl = "apply-resource-filter-by-sdl";
        public const string ApplyResourceFilterByProject = "apply-resource-filter-by-project";
        public const string ApplyResourceFilterByDateWeek = "apply-resource-filter-by-date-week";
        public const string ApplyResourceFilterBySearch = "apply-resource-filter-by-search";
        //END resources
        //BEGIN attributes
        public const string ViewBillTypes = "view-bill-types";
        public const string ViewResourceTypes = "view-resource-types";
        public const string CreateResourceTypes = "create-resource-types";
        public const string EditResourceTypes = "edit-resource-types";
        public const string DeleteResourceTypes = "delete-resource-types";
        public const string DeleteProjectResourceTypes = "delete-project-resource-types";
        //END attributes
        //BEGIN customers
        public const string ViewCustomers = "view-customers";
        public const string CreateCustomers = "create-customers";
        public const string EditCustomers = "edit-customers";
        public const string DeleteCustomers = "delete-customers";
        //END customers
        //BEGIN Users
        public const string ViewSdls = "view-sdls";
        //BEGIN Reports
        public const string ViewReports = "view-reports";
        public const string ViewReportsIntacctPowerbi = "view-reports-intacct-powerbi";
        public const string ViewReportsSdlProjects = "view-reports-sdl-projects";
        public const string ViewReportsCustomerTracker = "view-reports-customer-tracker";
        public const string ExportSdlProjectReports = "export-sdl-project-reports";
        //END Reports
        //BEGIN Settings
        public const string ViewSettings = "view-settings";
        public const string ViewSettingsUsers = "view-settings-users";
        public const string ViewSettingsRoles = "view-settings-roles";
        public const string ViewSettingsPermissions = "view-settings-permissions";
        public const string ViewSettingsAttributes = "view-settings-attributes";
        public const string ViewSettingsCustomers = "view-settings-customers";
        public const string ViewSettingsSdls = "view-settings-sdls";
        public const string ViewSettingsTemplates = "view-settings-templates";
        public const string ViewSettingsImports = "view-settings-imports";
        public const string ViewSettingsActivityLog = "view-settings-activity-log";
        //END Settings
        //roles crud
        public const string CreateRoles = "create-roles";
        public const string EditRoles = "edit-roles";
        public const string DeleteRoles = "delete-roles";
        public const string AssignPermissionToRole = "assign-permission-to-role";
        public const string RemovePermissionFromRole = "remove-permission-from-role";
        //permissions crud
        public const string CreatePermissions = "create-permissions";
        public const string EditPermissions = "edit-permissions";
        public const string DeletePermissions = "delete-permissions";
        //end roles and permissions
        //BEGIN users
        public const string InviteUser = "invite-user";
        public const string EditUser = "edit-user";
        public const string DeleteUser = "delete-user";
        public const string ActivateUser = "activate-user";
        public const string DeactivateUser = "deactivate-user";

        //BEGIN intacct
        public const string ImportIntacctTimesheets = "import-intacct-timesheets";
        public const string ViewIntacctEmployees = "view-intacct-employees";
        //BEGIN  templates
        public const string ViewTemplates = "view-templates";
        public const string UploadTemplates = "upload-templates";
        public const string DownloadTemplates = "download-templates";
        public const string DeleteTemplates = "delete-templates";
        public const string ManageTemplates = "manage-templates";

        //employee
        public const string ViewEmployeeAllocations = "view-employee-allocations";

        //email configurations
        public const string ViewEmailConfigurations = "view-email-configurations";
        public const string CreateEmailConfigurations = "create-email-configurations";
        public const string EditEmailConfigurations = "edit-email-configurations";
        public const string DeleteEmailConfigurations = "delete-email-configurations";
        //nav menu configurations
        public const string ViewNavMenuConfigurations = "view-nav-menu-configurations";
        public const string CreateNavMenuConfigurations = "create-nav-menu-configurations";
        public const string EditNavMenuConfigurations = "edit-nav-menu-configurations";
        public const string DeleteNavMenuConfigurations = "delete-nav-menu-configurations";
    }
}
