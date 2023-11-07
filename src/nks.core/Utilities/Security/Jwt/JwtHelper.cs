using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace nkskn.core.Security;

public class JwtHelper : IJwtHelper
{
    protected IConfiguration Configuration {get; }
    private TokenOptions _tokenOptions { get; }
    private DateTime _accessTokenExpiration;
    public JwtHelper(IConfiguration configuration)
    {
        Configuration = configuration;
        _tokenOptions = (TokenOptions) Configuration.GetSection("TokenOptions");
        _accessTokenExpiration = DateTime.UtcNow.AddMilliseconds(_tokenOptions.AccessTokenExpiration);
    }

    public AccessToken CreateToken(List<KeyValuePair<string, string>> userInfo, List<KeyValuePair<string, string>> operationClaims)
    {
        var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
        var signingCredentials = SigningCredentialsHelper.CreateCredentials(securityKey);
        var jwt = CreateJwtSecurityToken(_tokenOptions, signingCredentials, userInfo, operationClaims);
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var token = jwtSecurityTokenHandler.WriteToken(jwt);
        return new AccessToken(){
            Token = token,
            Expiration = _accessTokenExpiration
        };
    }

    public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, SigningCredentials signingCredentials, 
        List<KeyValuePair<string, string>> userInfo, List<KeyValuePair<string, string>> operationClaims)
    {
        var claims = SetClaims(userInfo, operationClaims);
        var jwt = new JwtSecurityToken(
            issuer: tokenOptions.Issuer,
            audience: tokenOptions.Audience,
            expires: _accessTokenExpiration,
            notBefore: DateTime.UtcNow,
            signingCredentials: signingCredentials,
            claims: claims
        );
        return jwt;
    }

    private IList<Claim> SetClaims(List<KeyValuePair<string, string>> userInfo, List<KeyValuePair<string, string>> operationClaims)
    {
        var claims = userInfo.Select(o => new Claim(type: o.Key, value: o.Value)).ToList();
        operationClaims.ForEach( claim => claims.Add(new Claim(ClaimTypes.Role, value: claim.Value)));
        return claims;
    }

}
