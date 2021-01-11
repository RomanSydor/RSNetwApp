using RSNetwApp.Domain.Entities.AdminsVM;
using RSNetwApp.Domain.Entities.EntitiesVM;
using RSNetwApp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSNetwApp.Services.Interfaces
{
    public interface IUserProfileService
    {
        Task<IEnumerable<UserProfileVM>> GetUserProfileEntitiesAsync();
        Task<bool> CreateUserProfileAsync(RegistrationModel registration);
        Task<UserProfileVM> GetUserProfileByUsernameAsync(string username);
        Task<UserProfileAVM> AdminGetUserProfileByUsernameAsync(string username);
    }
}
