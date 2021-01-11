using RSNetwApp.Domain.Entities.Enums;

namespace RSNetwApp.Domain.Entities.AdminsVM
{
    public class UserProfileAVM
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Roles? Role { get; set; }
    }
}
