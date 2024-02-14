using Appointments.Dto.RequestDto;
using Appointments.Dto.ResponseDto;

namespace Appointments.Services.UserService
{
    public interface IUserService
    {
        public Task<UserResDto> SignUp(UserReqDto userReqDto);

        public Task<string> Login(string email, string password);
    }
}
