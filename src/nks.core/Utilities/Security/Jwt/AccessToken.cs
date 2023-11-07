namespace nkskn.core.Security;

public class AccessToken
{
    public string Token { get; set; } = string.Empty;
    public DateTime  Expiration { get; set; }
}
