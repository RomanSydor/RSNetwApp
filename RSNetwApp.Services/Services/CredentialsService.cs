using RSNetwApp.Domain.Entities;
using RSNetwApp.Domain.Models;
using RSNetwApp.Repositories.Interfaces;
using RSNetwApp.Services.Interfaces;
using System.Threading.Tasks;

namespace RSNetwApp.Services.Services
{
    public class CredentialsService : ICredentialsService
    {
        private ICredentialsRepository _repository;
        public CredentialsService(ICredentialsRepository repository)
        {
            _repository = repository;
        }

        public async Task<CredentialsEntity> GetCredentialsAsync(AuthenticateRequest authenticate)
        {
            var credentials = await _repository.GetCredentialsAsync(authenticate);
            if (credentials == null)
            {
                return null;
            }

            return credentials;
        }
    }
}
