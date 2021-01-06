using RSNetwApp.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSNetwApp.Domain.Entities
{
    [Table("CredentialsEntities")]
    public class CredentialsEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Roles Role { get; set; }


        public UserProfileEntity UserProfile { get; set; }
    }
}
