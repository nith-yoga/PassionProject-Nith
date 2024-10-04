using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PassionProject_Nith.Models;

namespace PassionProject_Nith.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // Users.cs will map to a "Users" table
        public DbSet<User> Users {  get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Track> Tracks { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
