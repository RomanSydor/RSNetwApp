using Microsoft.IdentityModel.Tokens;

namespace RSNetwApp.Api.AccessTokenProvider
{
    public interface IJwtSigningEncodingKey
    {
        string SigningAlgorithm { get; }
        SecurityKey GetKey();
    }
}
