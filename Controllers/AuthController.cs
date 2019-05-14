using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZenDerivco.Models;
using ZenDerivco.Models.Repositroy;
using Microsoft.Extensions.Configuration;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Collections.Generic;
using ZenDerivco.Models.Repository;
using Microsoft.AspNetCore.Cors;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZenDerivco.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;
       

        public AuthController(IAuthRepository authRepository, IConfiguration configuration)
        {
            _repo = authRepository;
            _config = configuration;
        }


        [HttpPost]
        public IActionResult Login([FromBody] Employee loginDto)
        {
            var userFromRepo = _repo.Login(loginDto.UserId, loginDto.Password);
            if (userFromRepo == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.UserId.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                 .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),                
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
           
            var token = tokenHandler.CreateToken(tokenDescriptor);
            

            return Ok(new { token = tokenHandler.WriteToken(token), email = userFromRepo.Email, fullname = userFromRepo.FirstName + " " + userFromRepo.LastName });
        }


    }
}
