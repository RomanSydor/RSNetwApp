using RSNetwApp.Domain.Entities;
using RSNetwApp.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSNetwApp.Services.Interfaces
{
    public interface IUserProfileService
    {
        Task<IEnumerable<UserProfileVM>> GetUserProfileEntitiesAsync();
    }
}
