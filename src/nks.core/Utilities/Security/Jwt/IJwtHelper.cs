namespace nkskn.core.Security;

public interface IJwtHelper
{
    AccessToken CreateToken(List<KeyValuePair<string, string>> userInfo, List<KeyValuePair<string, string>> operationClaims);
}
