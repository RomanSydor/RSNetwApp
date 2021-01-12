using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RSNetwApp.Domain.Entities;
using RSNetwApp.Domain.Entities.AdminsVM;
using RSNetwApp.Domain.Entities.EntitiesVM;
using RSNetwApp.Domain.Models;
using RSNetwApp.Repositories.Interfaces;
using RSNetwApp.Services.Interfaces;
using RSNetwApp.Services.MD5Hash;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSNetwApp.Services.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _repository;
        private readonly IMapper _mapper;
        private readonly MD5Hasher _hasher;
        public UserProfileService(IUserProfileRepository repository, IMapper mapper, MD5Hasher hasher)
        {
            _repository = repository;
            _mapper = mapper;
            _hasher = hasher;
        }

        public async Task<bool> CreateUserProfileAsync(RegistrationModel registration)
        {
            var profile = _mapper.Map<UserProfileEntity>(registration);
            profile.Credentials.Role = 0;
            profile.Credentials.Password = _hasher.HashPassword(registration.Password);
            return await _repository.CreateUserProfileAsync(profile);
        }

        public async Task<UserProfileVM> GetUserProfileByUsernameAsync(string username)
        {
            var profile = await _repository.GetUserProfileByUsernameAsync(username);
            var profileVM = _mapper.Map<UserProfileVM>(profile);

            return profileVM;
        }

        public async Task<UserProfileAVM> AdminGetUserProfileByUsernameAsync(string username)
        {
            var profile = await _repository.GetUserProfileByUsernameAsync(username);
            var profileAVM = _mapper.Map<UserProfileAVM>(profile);

            return profileAVM;
        }

        public async Task<IEnumerable<UserProfileVM>> GetUserProfileEntitiesAsync()
        {
            var profiles = await _repository.GetUserProfileEntitiesAsQueryable().ToListAsync();
            var profilesVM = _mapper.Map<List<UserProfileVM>>(profiles);
            return profilesVM;
        }
    }
}
