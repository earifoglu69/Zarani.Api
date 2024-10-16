using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Zarani.Common.Extentions;
using Zarani.Common.IOC;
using Zarani.Common.Settings;
using Zarani.Domain.Response;

namespace Zarani.Application.Services
{
    public class TokenService : ITokenService, IScopedService
    {
        private readonly ITokenOptionsSetting _tokenOptionsSetting;

        public TokenService(ITokenOptionsSetting tokenOptionsSetting)
        {
            _tokenOptionsSetting = tokenOptionsSetting;
        }
        public Task<LoginResponse> CreateTokenByUser(ClaimsPrincipal loginResult)
        {
            var accessTokenExpiration = DateTime.Now.AddHours(_tokenOptionsSetting.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.Now.AddHours(_tokenOptionsSetting.RefreshTokenExpiration);

            var accessTokenExpiration5 = DateTime.Now.AddHours(_tokenOptionsSetting.AccessTokenExpiration);
            var refreshTokenExpiration5 = DateTime.Now.AddHours(_tokenOptionsSetting.RefreshTokenExpiration);

            SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptionsSetting.SecurityKey);
            SigningCredentials signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);

            JwtSecurityToken jwt = new(
                issuer: _tokenOptionsSetting.Issuer,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetUserClaims(loginResult, _tokenOptionsSetting.Audiences),
                signingCredentials: signingCredentials
            );

            ArgumentNullException.ThrowIfNull(jwt);

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            string token = jwtSecurityTokenHandler.WriteToken(jwt);

            LoginResponse tokenResponseModel = new()
            {
                AccessToken = token,
                AccessTokenExpiration = accessTokenExpiration,
                ExpiresIn = Convert.ToInt32((accessTokenExpiration - DateTime.Now.AddMinutes(1)).TotalSeconds),

                RefreshToken = TokenHelper.CreateRefreshToken(),
                RefreshTokenExpiration = refreshTokenExpiration
            };

            return Task.FromResult(tokenResponseModel);
        }
        #region Utilities
        private static IEnumerable<Claim> SetUserClaims(ClaimsPrincipal user, List<string> audiences)
        {
            List<System.Security.Claims.Claim> claims = new();
            claims.AddJti();
            claims.AddAuds(audiences);
            claims.AddRange(user.Claims);

            return claims;
        }
        #endregion
    }
}
