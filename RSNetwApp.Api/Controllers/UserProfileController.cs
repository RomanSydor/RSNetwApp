using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RSNetwApp.Domain.Models;
using RSNetwApp.Services.Interfaces;
using System.Security.Claims;
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
            var result = await _service.CreateUserProfileAsync(registration);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
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
        [Authorize(Roles = "1")]
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
