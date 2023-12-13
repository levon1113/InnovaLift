using InnovaLift.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InnovaLift.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Text> Texts { get; set; }

        public DbSet<Image> Images { get; set; }
    }
}