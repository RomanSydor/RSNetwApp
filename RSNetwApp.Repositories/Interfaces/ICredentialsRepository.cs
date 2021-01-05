using RSNetwApp.Domain.Entities;
using RSNetwApp.Domain.Models;
using System.Threading.Tasks;

namespace RSNetwApp.Repositories.Interfaces
{
    public interface ICredentialsRepository
    {
        Task<CredentialsEntity> GetCredentialsAsync(AuthenticateRequest authenticate);
    }
}
