using AutoMapper;
using IS3IncomabWebApi.ApplicationLayer.Dto;
using IS3IncomabWebApi.DomainLayer.Entity;
using IS3IncomabWebApi.DomainLayer.StaticClass.Record;

namespace IS3IncomabWebApi.CrossLayer.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {

            /* CreateMap<Customer,CustomerDto>()
                .ForMember(destination=>destination.FullName, source => source.MapFrom(src=>src.FullName)).ReverseMap();*/
            CreateMap<Customer, CustomerDto>()
                .ForMember(ds => ds.Id, src => src.MapFrom(src => src.Id))
                .ForMember(ds => ds.FullName, src => src.MapFrom(src => src.FullName))
                .ForMember(ds => ds.Phone, src => src.MapFrom(src => src.Phone))
                .ForMember(ds => ds.IdentityCard, src => src.MapFrom(src => src.IdentityCard))
                .ForMember(ds => ds.Address, src => src.MapFrom(src => src.Address))
                .ForMember(ds => ds.IsWholeSaler, src => src.MapFrom(src => src.IsWholeSaler))
                .ForMember(ds => ds.CreateDate, src => src.MapFrom(src => src.CreateDate))
                .ForMember(ds => ds.ModifyDate, src => src.MapFrom(src => src.ModifyDate))
                .ForMember(ds => ds.CreateBy, src => src.MapFrom(src => src.CreateBy))
                .ForMember(ds => ds.ModifyBy, src => src.MapFrom(src => src.ModifyBy))
                .ForMember(ds => ds.IsActive, src => src.MapFrom(src => src.IsActive))
                .ReverseMap();


            CreateMap<Cylinder, CylinderDto>()
                .ForMember(ds => ds.Id, src => src.MapFrom(src => src.Id))
                .ForMember(ds => ds.Number, src=>src.MapFrom(src=>src.Number))
                .ForMember(ds => ds.ModifyDate, src => src.MapFrom(src => src.ModifyDate))
                .ForMember(ds => ds.CreateDate, src => src.MapFrom(src => src.CreateDate))
                .ForMember(ds => ds.CreateBy, src => src.MapFrom(src => src.CreateBy))
                .ForMember(ds => ds.ModifyBy, src => src.MapFrom(src => src.ModifyBy))
                .ForMember(ds => ds.IsActive, src => src.MapFrom(src => src.IsActive))
                .ReverseMap();
            CreateMap<Cylinder, CylinderDto>()
                .ForMember(ds => ds.Status, src => src.MapFrom(src => Status.StatusGetId(src.StatusId)))
                .ForMember(ds => ds.TypeCylinder, src => src.MapFrom(src => TypeCylinder.TypeCylinderGetId(src.TypeCylinderId)));
            CreateMap<CylinderDto,Cylinder>()
                .ForMember(ds => ds.StatusId, src => src.MapFrom(src => src.Status.Id))
                .ForMember(ds => ds.TypeCylinderId, src => src.MapFrom(src => src.TypeCylinder.Id));
            ;
            CreateMap<DetailTicketCylinder, DetailTicketCylinderDto>().ReverseMap();
            CreateMap<Ticket, TicketDto>().ReverseMap();
            CreateMap<UserIncomab, UserDto>().ReverseMap();
        }

      
    }
}
