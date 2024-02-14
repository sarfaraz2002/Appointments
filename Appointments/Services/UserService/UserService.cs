using Appointment.Utilities;
using Appointments.DataContext;
using Appointments.Dto.RequestDto;
using Appointments.Dto.ResponseDto;
using Appointments.Models;
using Microsoft.EntityFrameworkCore;


namespace Appointments.Services.UserService
{
    public class UserService:IUserService
    {
        private readonly DbDataContext _dbConnection;
        private readonly TokenUtility _tokenUtility;
        public UserService(DbDataContext dbConnection, TokenUtility tokenUtility)
        {
            _dbConnection = dbConnection;
            _tokenUtility = tokenUtility;
        }

        public async Task<string> Login(string email, string password)
        {
            if (!ValidationUtility.IsValidEmail(email))
            {
                throw new Exception("Invalid Email");
            }

            User user = await _dbConnection.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                throw new Exception("User Not Found");
            }

            bool checkPassword = PasswordUtility.isPasswordValid(password, user.PasswordHash, user.PasswordSalt);
            if (!checkPassword)
            {
                throw new Exception("Password is wrong");
            }

            string token = _tokenUtility.GenerateJwtToken(user.Id, user.Name);
            return $"successfully logged in with token: {token}";
        }

        public async Task<UserResDto> SignUp(UserReqDto userReqDto)
        {
            if (!ValidationUtility.IsValidEmail(userReqDto.Email))
            {
                throw new Exception("Invalid Email");
            }

            if (!ValidationUtility.IsStrongPassword(userReqDto.Password))
            {
                throw new Exception("Try Strong Password");
            }
            PasswordUtility.createPassword(userReqDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            User user = new User
            {
                Email = userReqDto.Email,
                Name = userReqDto.Name,
                Phone = userReqDto.Phone,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedAt = DateTime.Now,
            };

            await _dbConnection.Users.AddAsync(user);
            await _dbConnection.SaveChangesAsync();

            return new UserResDto
            {
                Name = user.Name,
                Email = userReqDto.Email,
                Phone = userReqDto.Phone,
            };
        }
    }
}

