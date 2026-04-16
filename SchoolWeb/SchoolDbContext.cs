using Microsoft.EntityFrameworkCore;
using SchoolWeb.Models;
namespace SchoolWeb.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        public DbSet<Schueler> Schueler { get; set; }
        public DbSet<Klassenraum> Klassenraeume { get; set; }
        public DbSet<SchuelerKlassenraum> SchuelerKlassenraeume { get; set; }
        public DbSet<Lehrer> Lehrer { get; set; }
        public DbSet<Klasse> Klassen { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Schueler Configuration
            modelBuilder.Entity<Schueler>()
                .HasIndex(s => new { s.Geburtstag, s.Klasse })
                .IsUnique();

            // SchuelerKlassenraum Configuration
            modelBuilder.Entity<SchuelerKlassenraum>()
                .HasOne(sk => sk.Schueler)
                .WithMany(s => s.SchuelerKlassenraeume)
                .HasForeignKey(sk => sk.SchuelerId);

            modelBuilder.Entity<SchuelerKlassenraum>()
                .HasOne(sk => sk.Klassenraum)
                .WithMany(k => k.SchuelerKlassenraeume)
                .HasForeignKey(sk => sk.KlassenraumId);

            // Lehrer Configuration
            modelBuilder.Entity<Lehrer>()
                .HasIndex(l => l.Kuerzel)
                .IsUnique();

            modelBuilder.Entity<Lehrer>()
                .HasIndex(l => l.Email)
                .IsUnique();

            // Klasse Configuration
            modelBuilder.Entity<Klasse>()
                .HasIndex(k => k.Name)
                .IsUnique();

            // Beziehung zwischen Klasse und Lehrer (Klassenlehrer)
            modelBuilder.Entity<Klasse>()
                .HasOne(k => k.Klassenlehrer)
                .WithMany(l => l.BetreulteKlassen)
                .HasForeignKey(k => k.KlassenlehrerId)
                .OnDelete(DeleteBehavior.SetNull);
            // Standardwerte
            modelBuilder.Entity<Lehrer>()
                .Property(l => l.IstKlassenlehrer)
                .HasDefaultValue(false);

            modelBuilder.Entity<Lehrer>()
                .Property(l => l.Erfahrung)
                .HasDefaultValue(0);
        }
    }
}