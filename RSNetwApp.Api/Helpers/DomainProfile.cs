using AutoMapper;
using RSNetwApp.Domain.Entities;
using RSNetwApp.Domain.ViewModels;

namespace RSNetwApp.Api.Helpers
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<UserProfileEntity, UserProfileVM>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(m => m.UserName))
                .ForMember(u => u.FirstName, opt => opt.MapFrom(m => m.FirstName))
                .ForMember(u => u.LastName, opt => opt.MapFrom(m => m.LastName))
                .ForMember(u => u.Age, opt => opt.MapFrom(m => m.Age))
                .ForMember(u => u.Email, opt => opt.MapFrom(m => m.Email));
        }
    }
}
