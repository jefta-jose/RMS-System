using System;

namespace api.DTO.EmployeeType;

public class EmployeeTypeDto
{
    public long EmployeeTypeID { get; set; }
    public string EmployeeTypeName { get; set; }
}

public class EmployeeTypeResponseDto
{
    public long ID { get; set; }
    public string EmployeeTypeName { get; set; }
    public Guid EmployeeTypeID { get; set; }
}
