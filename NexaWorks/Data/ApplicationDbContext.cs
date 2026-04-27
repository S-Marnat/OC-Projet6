using Microsoft.EntityFrameworkCore;
using NexaWorks.Models;

namespace NexaWorks.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Produit> Produits { get; set; }
        public DbSet<NexaWorks.Models.Version> Versions { get; set; }
        public DbSet<Systeme> Systemes { get; set; }
        public DbSet<ProduitVersion> ProduitsVersions { get; set; }
        public DbSet<Probleme> Problemes { get; set; }
        public DbSet<Statut> Statuts { get; set; }
        public DbSet<Resolution> Resolutions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Clé composite
            modelBuilder.Entity<ProduitVersion>()
                .HasKey(pv => new { pv.IdProduit, pv.IdVersion });

            // Relations many-to-many
            modelBuilder.Entity<ProduitVersion>()
                .HasOne(pv => pv.Produit)
                .WithMany(p => p.ProduitsVersions)
                .HasForeignKey(pv => pv.IdProduit)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProduitVersion>()
                .HasOne(pv => pv.Version)
                .WithMany(v => v.ProduitsVersions)
                .HasForeignKey(pv => pv.IdVersion)
                .OnDelete(DeleteBehavior.Restrict);

            // Relations many-to-one
            modelBuilder.Entity<ProduitVersion>()
                .HasOne(pv => pv.Systeme)
                .WithMany(s => s.ProduitsVersions)
                .HasForeignKey(pv => pv.IdSysteme)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Probleme>()
                .HasOne(p => p.Produit)
                .WithMany(prod => prod.Problemes)
                .HasForeignKey(p => p.IdProduit)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Probleme>()
                .HasOne(p => p.Version)
                .WithMany(v => v.Problemes)
                .HasForeignKey(p => p.IdVersion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Probleme>()
                .HasOne(p => p.Systeme)
                .WithMany(s => s.Problemes)
                .HasForeignKey(p => p.IdSysteme)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Probleme>()
                .HasOne(p => p.Statut)
                .WithMany(s => s.Problemes)
                .HasForeignKey(p => p.IdStatut)
                .OnDelete(DeleteBehavior.Restrict);

            // Relation one-to-zero-or-one
            modelBuilder.Entity<Probleme>()
                .HasOne(p => p.Resolution)
                .WithOne(r => r.Probleme)
                .HasForeignKey<Resolution>(r => r.IdProbleme)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
