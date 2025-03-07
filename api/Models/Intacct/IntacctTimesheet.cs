using System;
namespace api.Models
{
    public class IntacctTimesheet
    {
        public long ID { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeLocationID { get; set; }
        public string EmployeeName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProjectID { get; set; }
        public string ProjLocationID { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ProjectName { get; set; }
        public string ProjectCategory { get; set; }
        public DateTime EntryDate { get; set; }
        public string ProjManager { get; set; }
        public decimal Hours { get; set; }
        public string Notes { get; set; }
        public string ProjType { get; set; }
        public DateTime TimeSheetBeginDate { get; set; }
        public string EmployeeType { get; set; }
        public string Level { get; set; }
        public string Task { get; set; }
        public string IntacctProjIDName { get; set; }
        public string FullName { get; set; }
        public string IntacctParentProjIDName { get; set; }
        public string ProjectStatus { get; set; }
        public DateTime CreatedDTM { get; set; }
        public long CreatedBy { get; set; }
    }
}