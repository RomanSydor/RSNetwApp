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

        public IQueryable<UserProfileEntity> GetUserProfileEntities()
        {
            var query = _db.UserProfileEntities.AsQueryable();
            return query;
        }
    }
}
