using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RSNetwApp.Domain.Entities
{
    [Table("UserProfileEntities")]
    public class UserProfileEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }

        [Required]
        public int CredentialsId { get; set; }
        public CredentialsEntity Credentials { get; set; }
    }
}
