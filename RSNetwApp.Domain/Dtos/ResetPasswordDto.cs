using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RSNetwApp.Domain.Dtos
{
    public class ResetPasswordDto
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Token { get; set; }

        [Required(ErrorMessage = "Field is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
