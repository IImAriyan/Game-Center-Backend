using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Game_center_Backend.Models;
using Microsoft.IdentityModel.Tokens;

namespace Services
{
    public class JWTToken()
    {

        public string GenerateJWTToken(UserEntity dto)
        {


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ZGR1Rq3eaEYXjjnraQDQ3mmkwntgn6qj"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                
                Subject = new ClaimsIdentity(new[]
                {   
                    new Claim(ClaimTypes.NameIdentifier,dto.Id.ToString()),
                    new Claim(ClaimTypes.Name,dto.Username),
                    new Claim(ClaimTypes.Email,dto.Email),
                    new Claim(ClaimTypes.Gender,dto.gender),
                    new Claim(ClaimTypes.Role,dto.adminRole),
                    new Claim(ClaimTypes.MobilePhone,dto.telephone)
                }),
                
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = creds,
                Issuer = "https://localhost:8080/api",
                Audience = "http://192.168.10.162:4000/"
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }


}
