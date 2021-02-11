using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using RSNetwApp.Domain.Dtos;

namespace RSNetwApp.Api.Helpers
{
    public class EmailHelper
    {
        private readonly IEmailSender _emailSender;

        public EmailHelper(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public Task ConfirmRegistrationSendRuMail(string callbackUrl, string userName, string email)
        {
            string html = "<body style=\"margin:0px\"> " +
                       "   <div class=\"back-email\" style=\"background-color:#220835;height:100%; font-family: 'HelveticaNeueCyr', Arial, sans-serif;p\">" +
                       $"Hi, {userName} <br>" +
                       $"Please, confirm your email <a href='{callbackUrl}'>here</a>" +
                       "  </div></body>";

            return _emailSender.SendEmailAsync(email, "Confirm your email", html);
        }

        public async Task SetPasswordSendRuMail(string callbackUrl, EmailUrlSenderDto model)
        {
            string html = $"Please, reset your password <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>here</a>.";
            await _emailSender.SendEmailAsync(model.Email, "Password reset", html);
        }
    }
}
