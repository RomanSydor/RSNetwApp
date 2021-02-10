using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RSNetwApp.Domain.Entities;
using RSNetwApp.Domain.ViewModels;
using RSNetwApp.Repositories.Interfaces;
using RSNetwApp.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSNetwApp.Services.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<UserProfileEntity> _userManager;
        public UserProfileService(IUserProfileRepository repository, IMapper mapper, UserManager<UserProfileEntity> userManager)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IEnumerable<UserProfileVM>> GetUserProfileEntitiesAsync()
        {
            var profilesQuery = _repository.GetUserProfileEntities();
            var profilesList = await profilesQuery.ToListAsync();
            var profiles = _mapper.Map<List<UserProfileVM>>(profilesList);
            return profiles;
        }

        public async Task<UserProfileVM> GetUserProfileAsync(string username) 
        {
            var profile = await _userManager.FindByNameAsync(username);
            return _mapper.Map<UserProfileVM>(profile);
        }
    }
}
