using Application.Common.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MultiProject.API.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly ILoginSignupRepository _loginSignupRepository;
        public TokenService(IConfiguration configuration, ILoginSignupRepository loginSignupRepository)
        {
            _configuration = configuration;
            _loginSignupRepository = loginSignupRepository;
        }

        public object GenerateToken(long userId, string otp)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("userid", userId.ToString()), new Claim("otp", otp.ToString()), new Claim(ClaimTypes.Role, string.Join(",", GetRoles(userId)))}),
                Expires = DateTime.UtcNow.AddDays(30),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new { token = tokenHandler.WriteToken(token), status = "Success" };
        }

        public string[] GetRoles(long userId) 
        {
            return _loginSignupRepository.getRoles(userId).Result.ReturnList.ToArray();
        }

    }
}
