using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RSNetwApp.Domain.Entities;
using RSNetwApp.Domain.ViewModels;
using RSNetwApp.Repositories.Interfaces;
using RSNetwApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSNetwApp.Services.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _repository;
        private readonly IMapper _mapper;
        public UserProfileService(IUserProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserProfileVM>> GetUserProfileEntitiesAsync()
        {
            var profilesQuery = _repository.GetUserProfileEntities();
            var profilesList = await profilesQuery.ToListAsync();
            var profiles = _mapper.Map<List<UserProfileVM>>(profilesList);
            return profiles;
        }
    }
}
