using AutoMapper;
using iSoft.Application.DTO.iSoft.Master.Request;
using iSoft.Application.DTO.iSoft.Master.Response;
using iSoft.Domain.Entity.iSoft.Master.identy;
using iSoft.Domain.Entity.iSoft.Master.master;

namespace iSoft.Cross.Mapper
{
    public class MappingsProfile : Profile
  {
    public MappingsProfile()
    {

      CreateMap<Authenticate, ResponseDtoAuthenticate>().ReverseMap();

      CreateMap<Status, ResponseDtoStatus>().ReverseMap();

      CreateMap<User, ResponseDtoUser>().ReverseMap();
      CreateMap<User, RequestDtoUser_Insert>().ReverseMap();
      CreateMap<User, RequestDtoUser_Update>().ReverseMap();

      CreateMap<Role, RequestDtoRole_Insert>().ReverseMap();
      CreateMap<Role, RequestDtoRole_Update>().ReverseMap();
      CreateMap<Role, ResponseDtoRole>().ReverseMap();

      CreateMap<Company, RequestDtoCompany_Insert>().ReverseMap();
      CreateMap<Company, RequestDtoCompany_Update>().ReverseMap();
      CreateMap<Company, ResponseDtoCompany>().ReverseMap();

      CreateMap<Role_x_Company, RequestDtoRole_x_Company_Insert>().ReverseMap();
      CreateMap<Role_x_Company, RequestDtoRole_x_Company_Update>().ReverseMap();
      CreateMap<Role_x_Company, ResponseDtoRole_x_Company>().ReverseMap();

      //CreateMap<Customers, CustomersDto>().ReverseMap()
      //    .ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.CustomerId))
      //    .ForMember(destination => destination.CompanyName, source => source.MapFrom(src => src.CompanyName))
      //    .ForMember(destination => destination.ContactName, source => source.MapFrom(src => src.ContactName))
      //    .ForMember(destination => destination.ContactTitle, source => source.MapFrom(src => src.ContactTitle))
      //    .ForMember(destination => destination.Address, source => source.MapFrom(src => src.Address))
      //    .ForMember(destination => destination.City, source => source.MapFrom(src => src.City))
      //    .ForMember(destination => destination.Region, source => source.MapFrom(src => src.Region))
      //    .ForMember(destination => destination.PostalCode, source => source.MapFrom(src => src.PostalCode))
      //    .ForMember(destination => destination.Country, source => source.MapFrom(src => src.Country))
      //    .ForMember(destination => destination.Phone, source => source.MapFrom(src => src.Phone))
      //    .ForMember(destination => destination.Fax, source => source.MapFrom(src => src.Fax)).ReverseMap();
    }
  }
}
