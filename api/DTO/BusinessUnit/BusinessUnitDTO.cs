using System;

namespace api.DTO.BusinessUnit;

public class BusinessUnitDto
{
    public long BusinessUnitID { get; set; }
    public string BusinessUnitName { get; set; }
}

public class BusinessUnitResponseDto
{
    public long ID { get; set; }
    public string BusinessUnitName { get; set; }
    public Guid BusinessUnitID { get; set; }

}