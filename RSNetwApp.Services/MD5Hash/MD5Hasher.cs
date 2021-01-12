using System;
using System.Security.Cryptography;
using System.Text;

namespace RSNetwApp.Services.MD5Hash
{
    public class MD5Hasher
    {
        public string HashPassword(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }
    }
}
