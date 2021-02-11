using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RSNetwApp.Domain.Dtos;
using RSNetwApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using RSNetwApp.Domain;
using Microsoft.AspNetCore.Http;
using RSNetwApp.Api.Helpers;

namespace RSNetwApp.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<UserProfileEntity> _userManager;
        private readonly IConfiguration _config;
        private readonly CallbackUrlHelper _callbackUrlHelper;
        private readonly EmailHelper _emailHelper;

        public AuthController(UserManager<UserProfileEntity> userManager, IConfiguration config, CallbackUrlHelper callbackUrlHelper, EmailHelper emailHelper)
        { 
            _userManager = userManager;
            _config = config;
            _callbackUrlHelper = callbackUrlHelper;
            _emailHelper = emailHelper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(UserLoginDto model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _config["JWT:ValidIssuer"],
                    audience: _config["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(4),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserRegisterDto model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            UserProfileEntity user = new UserProfileEntity()
            {
                Email = model.Email,
                Id = Guid.NewGuid().ToString(),
                UserName = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            //string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //string callbackUrl = _callbackUrlHelper.CreateCallbackUrl(user.Id, token, "ConfirmEmail");

            //await _emailHelper.ConfirmRegistrationSendRuMail(callbackUrl, user.UserName, user.Email);

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpGet]
        [Route("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User wasn't found!" });

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong!" });

            return Ok(new Response { Status = "Success", Message = "Email confirmed successfully!" });
        }

        [HttpPost]
        [Route("forgot-pass")]
        public async Task<IActionResult> ForgotPassword(EmailUrlSenderDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User wasn't found!" });
                }

                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Email isn't confirmed" });
                }

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                string callbackUrl = _callbackUrlHelper.CreateCallbackUrl(user.Id, token, "ResetPassword");

                try
                {
                    await _emailHelper.SetPasswordSendRuMail(callbackUrl, model);
                }
                catch (Exception exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = exception.Message });
                }
            }

            return Ok(new Response { Status = "Success", Message = "Please, check your email to reset your password." });
        }

        [HttpPost]
        [Route("reset-pass")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(viewModel.UserId);
                if (user == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User wasn't found!" });
                }

                var result = await _userManager.ResetPasswordAsync(user, viewModel.Token, viewModel.Password);
                if (result.Succeeded)
                {
                    return Ok(new Response { Status = "Success", Message = "Password successfully changed!" });
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong!" });
        }
    }

}
