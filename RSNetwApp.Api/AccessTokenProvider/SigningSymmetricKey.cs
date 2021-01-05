using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace RSNetwApp.Api.AccessTokenProvider
{
    public class SigningSymmetricKey : IJwtSigningDecodingKey, IJwtSigningEncodingKey
    {
        private readonly SymmetricSecurityKey _secretKey;

        public string SigningAlgorithm { get; } = SecurityAlgorithms.HmacSha256;

        public SigningSymmetricKey(string key)
        {
            this._secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }

        public SigningSymmetricKey()
        {

        }
        public SecurityKey GetKey() => this._secretKey;
    }
}
