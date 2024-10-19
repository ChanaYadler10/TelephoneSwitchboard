using AutoMapper;
using Repository.Models;
using Service.DTOs;
using System.Linq;
using TaskEntity = Repository.Models.Task; // Alias to differentiate between tasks

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Conversation, ConversationDto>().ReverseMap();

        CreateMap<Communication, CommunicationDto>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.CustomerTbl))
            .ForMember(dest => dest.ContactInfos, opt => opt.MapFrom(src => src.CustomerTbl.CustomerContactInfos.Select(cci => cci.ContactInfoTbl)))
            .ReverseMap();

        CreateMap<Customer, CustomerDto>()
            .ForMember(dest => dest.CustomerType, opt => opt.MapFrom(src => src.CustomerTypeTbl))
            .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.CustomerContactInfos.Select(cci => cci.ContactInfoTbl)))
            .ReverseMap();

        CreateMap<CustomerType, CustomerTypeDto>().ReverseMap();

        CreateMap<Address, AddressDto>()
            .ForMember(dest => dest.FullAddress, opt => opt.MapFrom(src =>
                string.Join(", ",
                    new[]
                    {
                        src.Address1,
                        src.City,
                        src.Country,
                    }.Where(s => !string.IsNullOrWhiteSpace(s))
                )
            ))
            .ReverseMap();

        CreateMap<ContactInfo, ContactInfoDto>().ReverseMap();
        CreateMap<Purchase, PurchaseDto>().ReverseMap();

        CreateMap<TaskEntity, TaskDto>()
            .ForMember(dest => dest.StatusTaskTbl, opt => opt.MapFrom(src => src.StatusTaskTbl))
            .ReverseMap();

        CreateMap<TaskCreateDto, TaskEntity>(); // Add this line for mapping TaskCreateDto to TaskEntity

        CreateMap<StatusTask, StatusTaskDto>().ReverseMap();
    }
}
