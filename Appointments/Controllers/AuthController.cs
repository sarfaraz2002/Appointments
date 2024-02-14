using Appointments.Dto.RequestDto;
using Appointments.Dto.ResponseDto;
using Appointments.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace Appointments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpPost("signup")]
        public async Task<ActionResult<UserResDto>> SignUp(UserReqDto userReqDto)
        {
            try
            {
                UserResDto user = await _userService.SignUp(userReqDto);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }

        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(string email, string password)
        {
            try
            {
                string token = await _userService.Login(email, password);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);

            }
        }
    }
}
