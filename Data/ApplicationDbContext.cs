using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using WebAtrioEmployeManagement.Models;

namespace WebAtrioEmployeManagement.Data
{
    public class ApplicationDbContext :  DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Emploi> Emplois { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Personne>()
                .HasMany(p => p.Emplois)
                .WithOne(e => e.Personne)
                .HasForeignKey(e => e.PersonneId);
        }
    }
}
