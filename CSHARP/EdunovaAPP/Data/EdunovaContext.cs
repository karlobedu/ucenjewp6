using EdunovaAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace EdunovaAPP.Data
{
    /// <summary>
    /// Kontekst baze podataka za aplikaciju Edunova.
    /// </summary>
    /// <remarks>
    /// Konstruktor koji prima opcije za konfiguraciju konteksta.
    /// </remarks>
    /// <param name="opcije">Opcije za konfiguraciju konteksta.</param>
    public class EdunovaContext(DbContextOptions<EdunovaContext> opcije) : DbContext(opcije)
    {

        /// <summary>
        /// Skup podataka za entitet Smjer.
        /// </summary>
        public DbSet<Smjer> Smjerovi { get; set; }

        /// <summary>
        /// Skup podataka za entitet Polaznik.
        /// </summary>
        public DbSet<Polaznik> Polaznici { get; set; }

        /// <summary>
        /// Skup podataka za entitet Grupa.
        /// </summary>
        public DbSet<Grupa> Grupe { get; set; }

        /// <summary>
        /// Skup podataka za entitet Operater.
        /// </summary>
        public DbSet<Operater> Operateri { get; set; }

        /// <summary>
        /// Konfiguracija modela prilikom kreiranja baze podataka.
        /// </summary>
        /// <param name="modelBuilder">Graditelj modela.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Implementacija veze 1:n
            modelBuilder.Entity<Grupa>().HasOne(g => g.Smjer);

            // Implementacija veze n:n
            modelBuilder.Entity<Grupa>()
                .HasMany(g => g.Polaznici)
                .WithMany(p => p.Grupe)
                .UsingEntity<Dictionary<string, object>>("clanovi",
                c => c.HasOne<Polaznik>().WithMany().HasForeignKey("polaznik"),
                c => c.HasOne<Grupa>().WithMany().HasForeignKey("grupa"),
                c => c.ToTable("clanovi")
                );
        }
    }
}
