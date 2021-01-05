using Microsoft.IdentityModel.Tokens;

namespace RSNetwApp.Api.AccessTokenProvider
{
    public interface IJwtSigningDecodingKey
    {
        SecurityKey GetKey();
    }
}
