using RSNetwApp.Domain.Entities;
using RSNetwApp.Domain.Models;
using RSNetwApp.Repositories.Interfaces;
using RSNetwApp.Services.Interfaces;
using RSNetwApp.Services.MD5Hash;
using System.Threading.Tasks;

namespace RSNetwApp.Services.Services
{
    public class CredentialsService : ICredentialsService
    {
        private readonly ICredentialsRepository _repository;
        private readonly MD5Hasher _hasher;
        public CredentialsService(ICredentialsRepository repository, MD5Hasher hasher)
        {
            _repository = repository;
            _hasher = hasher;
        }

        public async Task<CredentialsEntity> GetCredentialsAsync(AuthenticateRequest authenticate)
        {
            authenticate.Password = _hasher.HashPassword(authenticate.Password);
            var credentials = await _repository.GetCredentialsAsync(authenticate);
            if (credentials == null)
            {
                return null;
            }

            return credentials;
        }
    }
}
