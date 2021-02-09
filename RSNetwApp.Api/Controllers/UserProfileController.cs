using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        //[HttpGet]
        //[Route("Profiles/")]
        //public async Task<IActionResult> GetUserProfiles() 
        //{
        //    var profiles = await _service.GetUserProfileEntitiesAsync();
        //    return Ok(profiles);
        //}

        //[HttpGet]
        //[Route("CurrentProfile/")]
        //public async Task<IActionResult> CurrentProfile() 
        //{
        //    var username = User.Identity.Name;
        //    var profile = await _service.GetUserProfileByUsernameAsync(username);
        //    return Ok(profile);
        //}

        //[HttpGet]
        //[Route("Details/")]
        //public async Task<IActionResult> ProfileDetails(string username) 
        //{
        //    var profile = await _service.GetUserProfileByUsernameAsync(username);
        //    return Ok(profile);
        //}
    }
}
