using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RSNetwApp.Domain.Dtos
{
    public class EmailUrlSenderDto
    {
        [Required(ErrorMessage = "Field is required!")]
        [EmailAddress(ErrorMessage = "Invalid input!")]
        public string Email { get; set; }
    }
}
