using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SalesSystem.DTOs;
using SalesSystem.DTOs.Common;
using SalesSystem.DTOs.Response;
using SalesSystem.Models;
using SalesSystem.Tools;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Repositories.Implements
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly LESAContext lESAContext;
        private readonly AppSetthings appSetthings;

        public UserRepository(LESAContext lESAContext, IOptions<AppSetthings> appSetthings) : base(lESAContext)
        {
            this.lESAContext = lESAContext;
            this.appSetthings = appSetthings.Value;
        }

        public async Task<UserResponse> AuthenticationUser(UserDTO userDTO)
        {
            UserResponse userResponse = new UserResponse();
            string encryptedPassword = Encrypt.GetSHA256(userDTO.Password);

            var user = lESAContext.Users.Where(u => u.Email == userDTO.Email && 
                                                    u.Password == encryptedPassword).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            userResponse.Email = user.Email;
            userResponse.Token = GetToken(user);
            

            return userResponse;
        }

        private string GetToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(this.appSetthings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email)
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
