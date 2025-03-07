using System;
using System.Collections.Generic;

namespace api.DTO.Intacct;

public class IntacctTimesheetStatsDto
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int TotalRecords { get; set; }
    public int UploadedCurrentMonth { get; set; }
    public int UploadedPrevMonth { get; set; }
    public int TotalDuplicateRecords { get; set; }
    public List<IntacctTimesheetDto> DuplicateRecords { get; set; }
}