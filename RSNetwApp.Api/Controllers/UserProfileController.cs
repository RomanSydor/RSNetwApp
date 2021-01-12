using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RSNetwApp.Domain.Models;
using RSNetwApp.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace RSNetwApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _service;
        public UserProfileController(IUserProfileService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Profiles/")]
        public async Task<IActionResult> GetUserProfiles() 
        {
            var profiles = await _service.GetUserProfileEntitiesAsync();
            return Ok(profiles);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Create/")]
        public async Task<IActionResult> CreateUserProfile(RegistrationModel registration)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.SelectMany(x => x.Value.Errors)
                          .ToList();

                var error = string.Empty;
                foreach (var item in errors)
                {
                    error += $"{item.ErrorMessage} \n";   
                }
                return BadRequest(error);
            }
            var result = await _service.CreateUserProfileAsync(registration);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Username is already exists.");
        }

        [HttpGet]
        [Route("CurrentProfile/")]
        public async Task<IActionResult> CurrentProfile() 
        {
            var username = User.Identity.Name;
            var profile = await _service.GetUserProfileByUsernameAsync(username);
            return Ok(profile);
        }

        [HttpGet]
        [Route("Details/")]
        public async Task<IActionResult> ProfileDetails(string username) 
        {
            var profile = await _service.GetUserProfileByUsernameAsync(username);
            return Ok(profile);
        }

        [HttpGet]
        [Route("Details/Moderator/")]
        [Authorize(Roles = "1, 2")]
        public async Task<IActionResult> ModeratorProfileDetails(string username)
        {
            var profile = await _service.AdminGetUserProfileByUsernameAsync(username);
            return Ok(profile);
        }

        [HttpGet]
        [Route("Details/Admin/")]
        [Authorize(Roles = "2")]
        public async Task<IActionResult> AdminProfileDetails(string username)
        {
            var profile = await _service.AdminGetUserProfileByUsernameAsync(username);
            return Ok(profile);
        }
    }
}
