using AutoMapper;
using RSNetwApp.Domain.Entities;
using RSNetwApp.Domain.Entities.EntitiesVM;

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
        }
    }
}
