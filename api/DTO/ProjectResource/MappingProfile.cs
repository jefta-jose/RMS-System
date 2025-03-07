using System;
using AutoMapper;

namespace api.DTO.ProjectResource;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddProjectResourceDto, Models.ProjectResource>()
            .ForMember(x => x.CreatedDTM, opt => opt.MapFrom(src => DateTime.UtcNow))
        ;

        CreateMap<UpdateProjectResourceDto, Models.ProjectResource>()
            .ForMember(x => x.UpdatedDTM, opt => opt.MapFrom(src => DateTime.UtcNow))
        ;
    }
}