using AutoMapper;
using RSNetwApp.Domain.Entities;
using RSNetwApp.Domain.Entities.AdminsVM;
using RSNetwApp.Domain.Entities.EntitiesVM;
using RSNetwApp.Domain.Models;

namespace RSNetwApp.Api.Helpers
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<UserProfileEntity, UserProfileVM>()
                .ForMember(u => u.Username, opt => opt.MapFrom(m => m.Credentials.Username))
                .ForMember(u => u.FirstName, opt => opt.MapFrom(m => m.FirstName))
                .ForMember(u => u.LastName, opt => opt.MapFrom(m => m.LastName))
                .ForMember(u => u.Age, opt => opt.MapFrom(m => m.Age));

            CreateMap<UserProfileEntity, UserProfileAVM>()
               .ForMember(u => u.Username, opt => opt.MapFrom(m => m.Credentials.Username))
               .ForMember(u => u.FirstName, opt => opt.MapFrom(m => m.FirstName))
               .ForMember(u => u.LastName, opt => opt.MapFrom(m => m.LastName))
               .ForMember(u => u.Age, opt => opt.MapFrom(m => m.Age))
               .ForMember(u => u.Role, opt => opt.MapFrom(m => m.Credentials.Role));

            CreateMap<RegistrationModel, UserProfileEntity>()
                .AfterMap((src, dest) => {
                    dest.FirstName = src.FirstName;
                    dest.LastName = src.LastName;
                    dest.Age = src.Age;
                    dest.Credentials = new CredentialsEntity();
                    dest.Credentials.Username = src.Username;
                });
                
        }
    }
}
