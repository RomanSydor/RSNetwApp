using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RSNetwApp.Api.AccessTokenProvider;
using RSNetwApp.Domain.Models;
using RSNetwApp.Services.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RSNetwApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private ICredentialsService _credentialsService;

        public AuthenticateController(ICredentialsService credentialsService)
        {
            _credentialsService = credentialsService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Token/")]
        public async Task<ActionResult<string>> PostToken(AuthenticateRequest authenticate, [FromServices] IJwtSigningEncodingKey signingEncodingKey)
        {
            var credentials = await _credentialsService.GetCredentialsAsync(authenticate);

            if (credentials == null)
            {
                return NotFound("Invalid login or password");
            }

            var claims = new Claim[]
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, credentials.Username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, ((int)credentials.Role).ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "RSApp",
                audience: "RSAppClient",
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: new SigningCredentials(
                        signingEncodingKey.GetKey(),
                        signingEncodingKey.SigningAlgorithm)
            );

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }
    }
}
