using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RSNetwApp.Domain.Entities;
using RSNetwApp.Domain.Entities.EntitiesVM;
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

        public async Task<bool> CreateUserProfileAsync(UserProfileEntity userProfile)
        {
            return await _repository.CreateUserProfileAsync(userProfile);
        }

        public async Task<UserProfileVM> GetUserProfileByUsernameAsync(string username)
        {
            var profile = await _repository.GetUserProfileByUsernameAsync(username);
            var profileVM = _mapper.Map<UserProfileVM>(profile);
            return profileVM;
        }

        public async Task<IEnumerable<UserProfileVM>> GetUserProfileEntitiesAsync()
        {
            var profiles = await _repository.GetUserProfileEntitiesAsQueryable().ToListAsync();
            var profilesVM = _mapper.Map<List<UserProfileVM>>(profiles);
            return profilesVM;
        }
    }
}
