using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace api.DTO.Intacct;

public class IntacctTimesheetDto
{
    public long ID { get; set; }
    [Required(ErrorMessage = "EmployeeID is required")]
    public string EmployeeID { get; set; }
    public string Email { get; set; }
    public string EmployeeLocationID { get; set; }
    public string EmployeeName { get; set; }
    public string FullName { get; set; }
    [Required(ErrorMessage = "FirstName is required")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "LastName is required")]
    public string LastName { get; set; }
    public string ProjectID { get; set; }
    public string ProjLocationID { get; set; }

    public string ProjectLocationID
    {
        get
        {
            return ProjLocationID;
        }
        set
        {
            ProjLocationID = value;
        }
    }
    public string CustomerID { get; set; }
    public string CustomerName { get; set; }
    [Required(ErrorMessage = "ProjectName is required")]
    public string ProjectName { get; set; }
    [Required(ErrorMessage = "EntryDate is required")]
    public DateTime EntryDate { get; set; }
    public string ProjManager { get; set; }
    public string ProjectManager
    {
        get
        {
            return ProjManager;
        }
        set
        {
            ProjManager = value;
        }
    }
    [Required(ErrorMessage = "Hours is required")]
    public decimal Hours { get; set; }
    public string Notes { get; set; }
    public string ProjType { get; set; }

    public string ProjectType
    {
        get
        {
            return ProjType;
        }
        set
        {
            ProjType = value;
        }
    }
    public DateTime TimeSheetBeginDate { get; set; }
    public string EmployeeType { get; set; }
    public string Level { get; set; }
    public string Task { get; set; }
    public string IntacctProjIDName { get; set; }
    public string IntacctParentProjIDName { get; set; }
    public string ProjectCategory { get; set; }

    public string IntacctProjectIdName
    {
        get
        {
            return IntacctProjIDName;
        }
        set
        {
            IntacctProjIDName = value;
        }
    }

    public string IntacctParentProjectIDName
    {
        get
        {
            return IntacctParentProjIDName;
        }
        set
        {
            IntacctParentProjIDName = value;
        }
    }
    public string ProjectStatus { get; set; }

    public DateTime CreatedDTM { get; set; }
    public BigInteger CreatedBy { get; set; }
}