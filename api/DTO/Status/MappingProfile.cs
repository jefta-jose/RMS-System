using AutoMapper;

namespace api.DTO.Status;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Models.Status, StatusDto>().ReverseMap();
        CreateMap<Models.StatusGroup, StatusGroupDto>().ReverseMap();
    }
}