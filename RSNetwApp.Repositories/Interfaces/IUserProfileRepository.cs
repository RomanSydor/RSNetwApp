using RSNetwApp.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace RSNetwApp.Repositories.Interfaces
{
    public interface IUserProfileRepository
    {
        IQueryable<UserProfileEntity> GetUserProfileEntities();
    }
}
