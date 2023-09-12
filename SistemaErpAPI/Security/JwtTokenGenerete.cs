using Microsoft.IdentityModel.Tokens;
using Models.Modelos.Users;
using Models.TokenConfig;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JsonWebTokens = Microsoft.IdentityModel.JsonWebTokens;

namespace SistemaErpAPI.Security
{
    public class JwtTokenGenerete
    {
        public IConfiguration configuration;

        public JwtTokenGenerete(IConfiguration configuration)
        {
            this.configuration = configuration;     
        }

        public string GetToken(User user)
        {
            var jwt = configuration.GetSection("JWT").Get<JwtConfig>();

            var claims = new[]
            {
                new Claim(JsonWebTokens.JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JsonWebTokens.JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Id", user.Id.ToString()),
                new Claim("UserName", user.Name),
                new Claim("Password", user.Password),
                new Claim("Cate", user.Password),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                    jwt.Issuer,
                    jwt.Audience,
                    claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signIn
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool IsTokenValid(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = configuration.GetSection("JWT").Get<JwtConfig>();

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwt.Key)),
                ValidateIssuer = true,
                ValidIssuer = jwt.Issuer,
                ValidateAudience = true,
                ValidAudience = jwt.Audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                var claimsPrincipal = tokenHandler.ValidateToken(token.Replace("Bearer ", ""), validationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Guid GetLoggedId(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var decodedToken = handler.ReadJwtToken(token.Replace("Bearer ", ""));
                var userId = decodedToken.Claims.FirstOrDefault(claim => claim.Type == "Id")?.Value;
                return Guid.Parse(userId);

            }
            catch (Exception ex)
            {
                return Guid.Empty;
            }
        }
    }
}
