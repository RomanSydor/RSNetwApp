using Microsoft.EntityFrameworkCore;
using RSNetwApp.Domain.Entities;
using RSNetwApp.Repositories.Interfaces;
using RSNetwApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSNetwApp.Services.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _repository;
        public UserProfileService(IUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateUserProfileAsync(UserProfileEntity userProfile)
        {
            return await _repository.CreateUserProfileAsync(userProfile);
        }

        public async Task<UserProfileEntity> GetUserProfileByUsernameAsync(string username)
        {
            return await _repository.GetUserProfileByUsernameAsync(username);
        }

        public async Task<IEnumerable<UserProfileEntity>> GetUserProfileEntitiesAsync()
        {
            return await _repository.GetUserProfileEntitiesAsQueryable().ToListAsync();
        }
    }
}
