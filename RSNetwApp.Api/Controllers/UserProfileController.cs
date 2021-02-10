using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RSNetwApp.Domain.Entities;
using RSNetwApp.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace RSNetwApp.Api.Controllers
{
    [Route("api/user-profile")]
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
        [Route("profiles")]
        public async Task<IActionResult> GetUserProfiles()
        {
            var profiles = await _service.GetUserProfileEntitiesAsync();
            return Ok(profiles);
        }

        [HttpGet]
        [Route("current-profile")]
        public async Task<IActionResult> CurrentProfile()
        {
            var username = User.Identity.Name;
            var profile = await _service.GetUserProfileAsync(username);
            return Ok(profile);
        }

        [HttpGet]
        [Route("details")]
        public async Task<IActionResult> ProfileDetails(string username)
        {
            var profile = await _service.GetUserProfileAsync(username);
            return Ok(profile);
        }
    }
}
