using System;
using System.Collections.Generic;
using ExcelDataReader;

namespace api.DTO.Resource;

public class ResourceUploadDto
{
    public void InitResource(IExcelDataReader reader, Dictionary<string, int> column)
    {
        FirstName = reader.GetString(column["FIRSTNAME"]);
        LastName = reader.GetString(column["LASTNAME"]);
        AccountingID = reader.GetString(column["EMPLOYEEID"]);
        Level = reader.IsDBNull(column["LEVEL"]) ? (byte)1 : byte.Parse(reader.GetString(column["LEVEL"]));
        StartDate = reader.IsDBNull(column["STARTDATE"]) ? DateTime.Now : reader.GetDateTime(column["STARTDATE"]);
        EndDate = reader.IsDBNull(column["ENDDATE"]) ? null : reader.GetDateTime(column["ENDDATE"]);
        Email = reader.GetString(column["PRIMARYEMAILADDRESS"]);
    }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; }
    public string AccountingID { get; set; }
    public byte Level { get; set; } = 1;
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime? EndDate { get; set; }
}
