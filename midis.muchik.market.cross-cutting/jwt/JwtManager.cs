using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using midis.muchik.market.crosscutting.interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace midis.muchik.market.crosscutting.jwt
{
    public class JwtManager : IJwtManger
    {
        private readonly IConfiguration _configuration;

        public JwtManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(string userId, string email, string role) 
        {
            var issuer = _configuration.GetValue<string>("JwtConfig:Issuer");
            var audience = _configuration.GetValue<string>("JwtConfig:Audience");
            var secretKey = _configuration.GetValue<string>("JwtConfig:SecretKey");
            var lifetime = _configuration.GetValue<int>("JwtConfig:Lifetime");


            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            var claims = new[]
            {
                new Claim(ClaimTypes.Sid, userId),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role)
            };

            var payload = new JwtPayload(issuer, audience, claims, DateTime.UtcNow, DateTime.UtcNow.AddSeconds(lifetime));

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
