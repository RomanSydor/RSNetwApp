using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RSNetwApp.Api.Helpers
{
    public class CallbackUrlHelper
    {
        private readonly IConfiguration _config;

        public CallbackUrlHelper(IConfiguration config)
        {
            _config = config;
        }

        public string CreateCallbackUrl(string userId, string token, string action)
        {
            string callbackUrl =
                new string($"{_config.GetValue<string>($"CallBackActions:{action}")}?" +
                $"userId={HttpUtility.UrlEncode(userId)}&" +
                $"token={HttpUtility.UrlEncode(token)}");
            return callbackUrl;
        }
    }
}
