using System;

namespace api.DTO.EarningType;

public class EarningTypeDto
{
    public long EarningTypeID { get; set; }
    public string EarningTypeName { get; set; }
}

public class EarningTypeResponseDto
{
    public long ID { get; set; }
    public string EarningTypeName { get; set; }
    public Guid EarningTypeID { get; set; }
}