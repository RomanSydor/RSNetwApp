using RSNetwApp.Domain.Entities;
using RSNetwApp.Domain.Entities.EntitiesVM;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSNetwApp.Services.Interfaces
{
    public interface IUserProfileService
    {
        Task<IEnumerable<UserProfileVM>> GetUserProfileEntitiesAsync();
        Task<bool> CreateUserProfileAsync(UserProfileEntity userProfile);
        Task<UserProfileVM> GetUserProfileByUsernameAsync(string username);
    }
}
