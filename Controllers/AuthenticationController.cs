using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PracticaWebAPI_CURSOS.Configurations;
using PracticaWebAPI_CURSOS.DTOs.RequestSecurity;
using PracticaWebAPI_CURSOS.DTOs.ResponseSecurity;
using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PracticaWebAPI_CURSOS.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtConfig _jwtConfig;


        public AuthenticationController(UserManager<IdentityUser> userManager, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);

                if (existingUser != null)
                {
                    return BadRequest(new RegisterResponse()
                    {
                        Errors = new List<string>()
                {
                    "El correo electrónico ya está en uso"
                },
                        Success = false
                    });
                }

                var newUser = new IdentityUser() { Email = user.Email, UserName = user.UserName };
                var isCreated = await _userManager.CreateAsync(newUser, user.Password);
                if (isCreated.Succeeded)
                {
                    var jwtToken = GenerateJwtToken(newUser);

                    return Ok(new RegisterResponse()
                    {
                        Success = true,
                        Token = jwtToken
                    });
                }
                else
                {
                    return BadRequest(new RegisterResponse()
                    {
                        Errors = isCreated.Errors.Select(x => x.Description).ToList(),
                        Success = false
                    });
                }
            }

            return BadRequest(new RegisterResponse()
            {
                Errors = new List<string>()
                {
                    "Error al cargar la información"
                },
                Success = false
            });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
        {
            if (ModelState.IsValid)
            {
                var existUser = await _userManager.FindByEmailAsync(user.Email);
                if (existUser == null)
                {
                    return BadRequest(new RegisterResponse()
                    {
                        Errors = new List<string>()
                {
                    "Error al iniciar sesión"
                },
                        Success = false
                    });
                }

                var isCorrect = await _userManager.CheckPasswordAsync(existUser, user.Password);
                if (!isCorrect)
                {
                    return BadRequest(new RegisterResponse()
                    {
                        Errors = new List<string>()
                {
                    "Error al cargar la información solicitada"
                },
                        Success = false
                    });
                }

                var jwtToken = GenerateJwtToken(existUser);

                return Ok(new RegisterResponse()
                {
                    Success = true,
                    Token = jwtToken
                });
            }

            return BadRequest(new RegisterResponse()
            {
                Errors = new List<string>()
                {
                    "Error al cargar la información solicitada"
                },
                Success = false
            });

        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var JwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = JwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtTken = JwtTokenHandler.WriteToken(token);

            return jwtTken;
        }
    }
}
