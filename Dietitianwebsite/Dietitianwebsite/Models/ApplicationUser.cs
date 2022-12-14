using MessagePack;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Dietitianwebsite.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Food> Foods { get; set; }
        public virtual ICollection<Programdiet> Programdiets { get; set; }


    }
}
