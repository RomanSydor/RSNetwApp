using RSNetwApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSNetwApp.Services.Interfaces
{
    public interface IUserProfileService
    {
        Task<IEnumerable<UserProfileEntity>> GetUserProfileEntitiesAsync();
        Task<bool> CreateUserProfileAsync(UserProfileEntity userProfile);
        Task<UserProfileEntity> GetUserProfileByUsernameAsync(string username);
    }
}
