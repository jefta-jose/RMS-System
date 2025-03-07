using AutoMapper;
using System;
using api.CQRS.Resources.Commands;

namespace api.DTO.Resource;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UpsertResourceDto, Models.Resource>()
            .ForMember(x => x.SolutionDeliveryLeaderID, opt => opt.Ignore())
            .ForMember(x => x.ResourceLocationID, opt => opt.Ignore())
            .ForMember(x => x.ResourceTypeId, opt => opt.Ignore())
            .ForMember(x => x.ResourceLevelId, opt => opt.Ignore())
            .ForMember(x => x.EmployeeTypeID, opt => opt.Ignore())
            .ForMember(x => x.EarningTypeID, opt => opt.Ignore())
            .ForMember(x => x.CreatedDTM, opt => opt.MapFrom(src => DateTime.UtcNow))
        ;

        CreateMap<UpdateResourceCommand, Models.Resource>()
            .ForMember(x => x.SolutionDeliveryLeaderID, opt => opt.Ignore())
            .ForMember(x => x.ResourceLocationID, opt => opt.Ignore())
            .ForMember(x => x.ResourceTypeId, opt => opt.Ignore())
            .ForMember(x => x.ResourceLevelId, opt => opt.Ignore())
            .ForMember(x => x.EmployeeTypeID, opt => opt.Ignore())
            .ForMember(x => x.EarningTypeID, opt => opt.Ignore())
            .ForMember(x => x.UpdatedBy, opt => opt.Ignore())
            .ForMember(x => x.ResourceId, opt => opt.Ignore())
            .ForMember(x => x.UpdatedDTM, opt => opt.MapFrom(src => DateTime.UtcNow))
        ;

        CreateMap<AddResourceCommand, Models.Resource>()
            .ForMember(x => x.SolutionDeliveryLeaderID, opt => opt.Ignore())
            .ForMember(x => x.ResourceLocationID, opt => opt.Ignore())
            .ForMember(x => x.ResourceTypeId, opt => opt.Ignore())
            .ForMember(x => x.ResourceLevelId, opt => opt.Ignore())
            .ForMember(x => x.EmployeeTypeID, opt => opt.Ignore())
            .ForMember(x => x.EarningTypeID, opt => opt.Ignore())
            .ForMember(x => x.CreatedDTM, opt => opt.MapFrom(src => DateTime.UtcNow))
        ;

        CreateMap<AddResourceCommand, UpsertResourceDto>().ReverseMap();
        CreateMap<UpdateResourceCommand, UpsertResourceDto>().ReverseMap();
    }
}