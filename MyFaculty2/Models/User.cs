using Microsoft.AspNetCore.Identity;

namespace MyFaculty2.Models
{
    public class User : IdentityUser 
    {
        public DateTime? BirthDate { get; set; }
        public int? TeacherId { get; set; }
    }
}
