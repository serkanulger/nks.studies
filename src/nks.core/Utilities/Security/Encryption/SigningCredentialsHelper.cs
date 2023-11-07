using Microsoft.IdentityModel.Tokens;

namespace nkskn.core.Security;

public class SigningCredentialsHelper
{
    public static SigningCredentials CreateCredentials(SecurityKey key)
    {
        return new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
    } 
}
