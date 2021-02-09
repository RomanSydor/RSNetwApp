using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RSNetwApp.Domain.Dtos
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name  is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Age  is required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "User name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

       

    }
}
