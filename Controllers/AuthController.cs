using Bookbox.DTOs.Request;
using Bookbox.DTOs.Response;
using Bookbox.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bookbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }
        //Post: /api/auth/register

        [HttpPost]
        [Route("Register")]

        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            //Username== Email
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };
            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);// Creating a new user
            if (identityResult.Succeeded)
            {
                //Add roles to this user
                if(registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult= await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                    if(identityResult.Succeeded)
                    {
                        return Ok("User registered successfully, Please login");
                    }
                }
            }
            return BadRequest("Something went wrong");
        }


        // POST: /api/Auth/Login

        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            //Checking if the email and Password match with the registered on in the database
             var user= await userManager.FindByEmailAsync(loginRequestDto.Username);
            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);
                if (checkPasswordResult)
                {
                    //Get roles for this user

                    var roles= await userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                        //Create Token
                      var jwtToken=  tokenRepository.CreateJWTToken(user, roles.ToList());
                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken
                        };
                      return Ok(response);

                    }

                } 
                
            }
            return BadRequest("Username or Password Incorrect");
        }
    }
}
