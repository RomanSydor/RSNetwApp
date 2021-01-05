using Microsoft.EntityFrameworkCore;
using RSNetwApp.Domain.Entities;
using RSNetwApp.Domain.Models;
using RSNetwApp.Repositories.Contexts;
using RSNetwApp.Repositories.Interfaces;
using System.Threading.Tasks;

namespace RSNetwApp.Repositories.Repositories
{
    public class CredentialsRepository : ICredentialsRepository
    {
        private readonly RSNetwDbContext _db;
        public CredentialsRepository(RSNetwDbContext db)
        {
            _db = db;
        }

        public async Task<CredentialsEntity> GetCredentialsAsync(AuthenticateRequest authenticate)
        {
            var credentials = await _db.CredentialsEntities
                                    .SingleOrDefaultAsync(x => x.Username == authenticate.Login && x.Password == authenticate.Password);
            return credentials;
        }
    }
}
