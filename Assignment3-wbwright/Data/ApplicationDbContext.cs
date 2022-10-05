using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Assignment3_wbwright.Models;

namespace Assignment3_wbwright.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Assignment3_wbwright.Models.Actor> Actor { get; set; }
        public DbSet<Assignment3_wbwright.Models.Movie> Movie { get; set; }
        public DbSet<Assignment3_wbwright.Models.ActorPerformedInMovie> ActorPerformedInMovie { get; set; }
    }
}