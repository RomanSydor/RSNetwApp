using RSNetwApp.Domain.Entities;
using RSNetwApp.Domain.Models;
using System.Threading.Tasks;

namespace RSNetwApp.Services.Interfaces
{
    public interface ICredentialsService
    {
        Task<CredentialsEntity> GetCredentialsAsync(AuthenticateRequest authenticate);
    }
}
