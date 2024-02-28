using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace Real_Estate_Api.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseViewModel GenerateToken(GetCheckUserViewModel getCheckUserViewModel)
        {
            List<Claim> claims = new List<Claim>();
            if (!string.IsNullOrWhiteSpace(getCheckUserViewModel.Role))
                claims.Add(new Claim(ClaimTypes.Role, getCheckUserViewModel.Role));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, getCheckUserViewModel.Id.ToString()));
            if (!string.IsNullOrWhiteSpace(getCheckUserViewModel.UserName))
                claims.Add(new Claim("Username", getCheckUserViewModel.UserName));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefault.Key));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiredDate = DateTime.UtcNow.AddDays(JwtTokenDefault.Expire);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
                (
                    issuer:JwtTokenDefault.ValidIssuer,
                    audience:JwtTokenDefault.ValidAudience,
                    claims: claims,
                    notBefore:DateTime.UtcNow,
                    expires:expiredDate,
                    signingCredentials:signingCredentials
                );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return new TokenResponseViewModel(tokenHandler.WriteToken(jwtSecurityToken),expiredDate);
        }
    }
}
