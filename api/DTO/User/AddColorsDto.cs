namespace api.DTO.User;

public class AddColorsDto
{
    public string Available { get; set; }
    public string Allocated { get; set; }
    public string Billable { get; set; }
    public string Nonbillable { get; set; }
    public string Headcount { get; set; }
    public string HeadcountBillable { get; set; }
    public string BillableHoursAvailable { get; set; }
    public string BillableHoursAllocated { get; set; }
}