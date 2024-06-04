using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AracKiralama.API.Models;

namespace AracKiralama.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
