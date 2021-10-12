using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using TimeTracking.Core.Abstraction;
using TimeTracking.Model;
using TimeTracking.WebAPI.Helpers;

namespace TimeTracking.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _configuration;
        private IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AuthenticateRequest authenticateRequest)
        {
            if(ModelState.IsValid)
            { 
                AuthenticateResponse response = await _userRepository.LoginAsync(authenticateRequest);

                if(response != null)
                {
                    string token = GenerateJSONWebToken(response);
                    response.Token = token;

                    return Ok(response);
                }
                else
                {
                    throw new AppException("Username or password is incorrect!!");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        private string GenerateJSONWebToken(AuthenticateResponse response)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var newClaims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, response.EmployeeName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                newClaims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
