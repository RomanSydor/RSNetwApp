using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RSNetwApp.Domain.Dtos
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "User Name or Email is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
