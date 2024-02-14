using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Appointment.Utilities
{
    public class TokenUtility
    {
        private readonly IConfiguration _configuration;
        public TokenUtility(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private string CreateJwtToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Secret").Value));

            var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(4),
                    signingCredentials: credentials

            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }

        public string GenerateJwtToken(long userId,string name)
        {
            List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Role, "user"),
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            new Claim(ClaimTypes.Name, name),
        };

            var token = CreateJwtToken(claims);
            Console.WriteLine(token);
            return token;
        }
    }

}
