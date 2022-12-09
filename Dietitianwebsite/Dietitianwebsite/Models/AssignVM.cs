using Microsoft.AspNetCore.Identity;

namespace Dietitianwebsite.Models
{
    public class AssignVM
    {
        public ApplicationUser UserId { get; set; }
        public IdentityRole RoleId { get; set; }

    }

    public class AssignVM2
    {
        public String email { get; set; }
        public string role { get; set; }

    }
}
