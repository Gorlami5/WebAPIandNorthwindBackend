using Business.Abstract;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:Controller
    {
        IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService; 
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _authService.Login(userForLoginDto);
            if (userToCheck.Success)
            {
                return BadRequest("Login failed");
            }

            var result = _authService.CreateToken(userToCheck.Data);
            if (result.Success)
            {
                return BadRequest("Token failed");
            }
            
            return Ok(result.Data);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userToExist = _authService.UserExist(userForRegisterDto.Email);
            if (!userToExist.Success)
            {
                return BadRequest("User already exist");
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            if (registerResult.Success)
            {
                return BadRequest("Register failed");
            }

            var result = _authService.CreateToken(registerResult.Data);
            if (!result.Success)
            {
                BadRequest("Register Token failed");
            }

            return Ok(result.Data);
        }
    }
}
