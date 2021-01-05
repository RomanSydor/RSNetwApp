using Microsoft.EntityFrameworkCore;
using RSNetwApp.Domain.Entities;
using RSNetwApp.Repositories.Contexts;
using RSNetwApp.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RSNetwApp.Repositories.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly RSNetwDbContext _db;

        public UserProfileRepository(RSNetwDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CreateUserProfileAsync(UserProfileEntity userProfile)
        {
            try
            {
                _db.UserProfileEntities.Add(userProfile);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<UserProfileEntity> GetUserProfileByUsernameAsync(string username)
        {
            var profile = await _db.UserProfileEntities
                             .Include(x => x.Credentials)
                             .SingleOrDefaultAsync(x => x.Credentials.Username == username);
            return profile;
        }

        public IQueryable<UserProfileEntity> GetUserProfileEntitiesAsQueryable()
        {
            var query = _db.UserProfileEntities
                .Include(x => x.Credentials)
                .AsQueryable();
            return query;
        }
    }
}
