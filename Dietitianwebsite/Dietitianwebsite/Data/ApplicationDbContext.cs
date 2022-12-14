using Dietitianwebsite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dietitianwebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
      

        public DbSet<Dietitianwebsite.Models.Food> Food { get; set; }
        public DbSet<Dietitianwebsite.Models.ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Dietitianwebsite.Models.Programdiet> Program { get; set; }

    }
}