using Microsoft.EntityFrameworkCore;
using NexaWorks.Models;

namespace NexaWorks.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Produit> Produits { get; set; }
        public DbSet<NexaWorks.Models.Version> Versions { get; set; }
        public DbSet<Systeme> Systemes { get; set; }
        public DbSet<ProduitVersionSysteme> ProduitsVersionsSystemes { get; set; }
        public DbSet<Probleme> Problemes { get; set; }
        public DbSet<Statut> Statuts { get; set; }
        public DbSet<Resolution> Resolutions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // -- Clé composite --
            modelBuilder.Entity<ProduitVersionSysteme>()
                .HasKey(pv => new { pv.IdProduit, pv.IdVersion, pv.IdSysteme });

            // -- Relations --
            // Relation ternaire
            modelBuilder.Entity<ProduitVersionSysteme>()
                .HasOne(pv => pv.Produit)
                .WithMany(p => p.ProduitsVersionsSystemes)
                .HasForeignKey(pv => pv.IdProduit)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProduitVersionSysteme>()
                .HasOne(pv => pv.Version)
                .WithMany(v => v.ProduitsVersionsSystemes)
                .HasForeignKey(pv => pv.IdVersion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProduitVersionSysteme>()
                .HasOne(pv => pv.Systeme)
                .WithMany(v => v.ProduitsVersionsSystemes)
                .HasForeignKey(pv => pv.IdSysteme)
                .OnDelete(DeleteBehavior.Restrict);

            // Relations many-to-one
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


            // -- Seed Data --
            modelBuilder.Entity<Produit>().HasData(
                new Produit { Id = 1, Nom = "Trader en Herbe" },
                new Produit { Id = 2, Nom = "Maître des Investissements" },
                new Produit { Id = 3, Nom = "Planificateur d'Entraînement" },
                new Produit { Id = 4, Nom = "Planificateur d'Anxiété Sociale" }
            );

            modelBuilder.Entity<NexaWorks.Models.Version>().HasData(
                new NexaWorks.Models.Version { Id = 1, Numero = "1.0" },
                new NexaWorks.Models.Version { Id = 2, Numero = "1.1" },
                new NexaWorks.Models.Version { Id = 3, Numero = "1.2" },
                new NexaWorks.Models.Version { Id = 4, Numero = "1.3" },
                new NexaWorks.Models.Version { Id = 5, Numero = "2.0" },
                new NexaWorks.Models.Version { Id = 6, Numero = "2.1" }
            );

            modelBuilder.Entity<Systeme>().HasData(
                new Systeme { Id = 1, Nom = "Linux" },
                new Systeme { Id = 2, Nom = "MacOS" },
                new Systeme { Id = 3, Nom = "Windows" },
                new Systeme { Id = 4, Nom = "Android" },
                new Systeme { Id = 5, Nom = "iOS" },
                new Systeme { Id = 6, Nom = "Windows Mobile" }
            );

            modelBuilder.Entity<ProduitVersionSysteme>().HasData(
                // Produit = Trader en Herbe
                // Version = 1.0
                new ProduitVersionSysteme { IdProduit = 1, IdVersion = 1, IdSysteme = 1 },
                new ProduitVersionSysteme { IdProduit = 1, IdVersion = 1, IdSysteme = 3 },
                // Version = 1.1
                new ProduitVersionSysteme { IdProduit = 1, IdVersion = 2, IdSysteme = 1 },
                new ProduitVersionSysteme { IdProduit = 1, IdVersion = 2, IdSysteme = 2 },
                new ProduitVersionSysteme { IdProduit = 1, IdVersion = 2, IdSysteme = 3 },
                // Version = 1.2
                new ProduitVersionSysteme { IdProduit = 1, IdVersion = 3, IdSysteme = 1 },
                new ProduitVersionSysteme { IdProduit = 1, IdVersion = 3, IdSysteme = 2 },
                new ProduitVersionSysteme { IdProduit = 1, IdVersion = 3, IdSysteme = 3 },
                new ProduitVersionSysteme { IdProduit = 1, IdVersion = 3, IdSysteme = 4 },
                new ProduitVersionSysteme { IdProduit = 1, IdVersion = 3, IdSysteme = 5 },
                new ProduitVersionSysteme { IdProduit = 1, IdVersion = 3, IdSysteme = 6 },
                // Version = 1.3
                new ProduitVersionSysteme { IdProduit = 1, IdVersion = 4, IdSysteme = 2 },
                new ProduitVersionSysteme { IdProduit = 1, IdVersion = 4, IdSysteme = 3 },
                new ProduitVersionSysteme { IdProduit = 1, IdVersion = 4, IdSysteme = 4 },
                new ProduitVersionSysteme { IdProduit = 1, IdVersion = 4, IdSysteme = 5 },

                // Produit = Maître des Investissements
                // Version = 1.0
                new ProduitVersionSysteme { IdProduit = 2, IdVersion = 1, IdSysteme = 2 },
                new ProduitVersionSysteme { IdProduit = 2, IdVersion = 1, IdSysteme = 5 },
                // Version = 2.0
                new ProduitVersionSysteme { IdProduit = 2, IdVersion = 5, IdSysteme = 2 },
                new ProduitVersionSysteme { IdProduit = 2, IdVersion = 5, IdSysteme = 4 },
                new ProduitVersionSysteme { IdProduit = 2, IdVersion = 5, IdSysteme = 5 },
                // Version = 2.1
                new ProduitVersionSysteme { IdProduit = 2, IdVersion = 6, IdSysteme = 2 },
                new ProduitVersionSysteme { IdProduit = 2, IdVersion = 6, IdSysteme = 3 },
                new ProduitVersionSysteme { IdProduit = 2, IdVersion = 6, IdSysteme = 4 },
                new ProduitVersionSysteme { IdProduit = 2, IdVersion = 6, IdSysteme = 5 },

                // Produit = Planificateur d'Entraînement
                // Version = 1.0
                new ProduitVersionSysteme { IdProduit = 3, IdVersion = 1, IdSysteme = 1 },
                new ProduitVersionSysteme { IdProduit = 3, IdVersion = 1, IdSysteme = 2 },
                // Version = 1.1
                new ProduitVersionSysteme { IdProduit = 3, IdVersion = 2, IdSysteme = 1 },
                new ProduitVersionSysteme { IdProduit = 3, IdVersion = 2, IdSysteme = 2 },
                new ProduitVersionSysteme { IdProduit = 3, IdVersion = 2, IdSysteme = 3 },
                new ProduitVersionSysteme { IdProduit = 3, IdVersion = 2, IdSysteme = 4 },
                new ProduitVersionSysteme { IdProduit = 3, IdVersion = 2, IdSysteme = 5 },
                new ProduitVersionSysteme { IdProduit = 3, IdVersion = 2, IdSysteme = 6 },
                // Version = 2.0
                new ProduitVersionSysteme { IdProduit = 3, IdVersion = 5, IdSysteme = 2 },
                new ProduitVersionSysteme { IdProduit = 3, IdVersion = 5, IdSysteme = 3 },
                new ProduitVersionSysteme { IdProduit = 3, IdVersion = 5, IdSysteme = 4 },
                new ProduitVersionSysteme { IdProduit = 3, IdVersion = 5, IdSysteme = 5 },

                // Produit = Planificateur d'Anxiété Sociale
                // Version = 1.0
                new ProduitVersionSysteme { IdProduit = 4, IdVersion = 1, IdSysteme = 2 },
                new ProduitVersionSysteme { IdProduit = 4, IdVersion = 1, IdSysteme = 3 },
                new ProduitVersionSysteme { IdProduit = 4, IdVersion = 1, IdSysteme = 4 },
                new ProduitVersionSysteme { IdProduit = 4, IdVersion = 1, IdSysteme = 5 },
                // Version = 1.1
                new ProduitVersionSysteme { IdProduit = 4, IdVersion = 2, IdSysteme = 2 },
                new ProduitVersionSysteme { IdProduit = 4, IdVersion = 2, IdSysteme = 3 },
                new ProduitVersionSysteme { IdProduit = 4, IdVersion = 2, IdSysteme = 4 },
                new ProduitVersionSysteme { IdProduit = 4, IdVersion = 2, IdSysteme = 5 }
            );

            modelBuilder.Entity<Statut>().HasData(
                new Statut { Id = 1, Nom = "En cours" },
                new Statut { Id = 2, Nom = "Résolu" }
            );

            modelBuilder.Entity<Probleme>().HasData(
                new Probleme
                {
                    Id = 1,
                    IdProduit = 1,
                    IdVersion = 1,
                    IdSysteme = 3,
                    IdStatut = 2,
                    Date = new DateTime(2024, 2, 15),
                    Description = "L’utilisateur signale que l’application affiche des soldes de portefeuille incohérents après la fermeture " +
                        "puis la réouverture de l’application : le solde affiché est parfois inférieur de plusieurs centaines d’euros par " +
                        "rapport au solde attendu."
                },
                new Probleme
                {
                    Id = 2,
                    IdProduit = 1,
                    IdVersion = 2,
                    IdSysteme = 2,
                    IdStatut = 2,
                    Date = new DateTime(2024, 4, 25),
                    Description = "L’interface se fige plusieurs secondes à l’ouverture d’un portefeuille contenant plus de 500 positions, " +
                        "rendant l’application non réactive."
                },
                new Probleme
                {
                    Id = 3,
                    IdProduit = 1,
                    IdVersion = 3,
                    IdSysteme = 1,
                    IdStatut = 2,
                    Date = new DateTime(2024, 7, 5),
                    Description = "La connexion OAuth échoue pour des comptes dont le nom d’utilisateur contient des caractères spéciaux, " +
                        "empêchant certains utilisateurs de se connecter."
                },
                new Probleme
                {
                    Id = 4,
                    IdProduit = 1,
                    IdVersion = 3,
                    IdSysteme = 4,
                    IdStatut = 1,
                    Date = new DateTime(2025, 10, 15),
                    Description = "L’application se déconnecte de manière aléatoire après 30–45 minutes d’inactivité sur certains appareils, " +
                        "surtout ceux avec des politiques d’économie d’énergie agressives."
                },
                new Probleme
                {
                    Id = 5,
                    IdProduit = 1,
                    IdVersion = 3,
                    IdSysteme = 6,
                    IdStatut = 2,
                    Date = new DateTime(2024, 8, 5),
                    Description = "Les notifications push ne sont pas reçues lorsque des événements critiques sont envoyés depuis le backend."
                },
                new Probleme
                {
                    Id = 6,
                    IdProduit = 1,
                    IdVersion = 4,
                    IdSysteme = 2,
                    IdStatut = 1,
                    Date = new DateTime(2025, 1, 12),
                    Description = "Lorsqu’un acheteur tente d’ajouter plusieurs articles à son panier en utilisant le bouton « Ajouter au panier », " +
                        "l’application ne met pas toujours à jour le nombre d’articles affiché dans le panier bien que les articles soient bien " +
                        "ajoutés en arrière‑plan, provoquant des erreurs d’achat."
                },
                new Probleme
                {
                    Id = 7,
                    IdProduit = 1,
                    IdVersion = 4,
                    IdSysteme = 4,
                    IdStatut = 2,
                    Date = new DateTime(2025, 2, 20),
                    Description = "L’application consomme excessivement la batterie en arrière‑plan, ce qui provoque des retours négatifs des utilisateurs."
                },
                new Probleme
                {
                    Id = 8,
                    IdProduit = 1,
                    IdVersion = 4,
                    IdSysteme = 5,
                    IdStatut = 1,
                    Date = new DateTime(2025, 3, 5),
                    Description = "Les favoris ajoutés sur un appareil iOS ne se synchronisent pas systématiquement sur les autres appareils de l’utilisateur, " +
                        "entraînant des pertes de favoris."
                },
                new Probleme
                {
                    Id = 9,
                    IdProduit = 2,
                    IdVersion = 1,
                    IdSysteme = 2,
                    IdStatut = 2,
                    Date = new DateTime(2024, 6, 1),
                    Description = "Les recherches de titres sont lentes et provoquent des timeouts sur des catalogues volumineux, " +
                        "rendant la fonctionnalité peu utilisable."
                },
                new Probleme
                {
                    Id = 10,
                    IdProduit = 2,
                    IdVersion = 5,
                    IdSysteme = 4,
                    IdStatut = 2,
                    Date = new DateTime(2024, 11, 10),
                    Description = "L’application se ferme immédiatement lorsque l’utilisateur tente d’ouvrir un graphique montrant l’évolution " +
                        "d’une action sur plusieurs mois contenant un très grand nombre de points de données."
                },
                new Probleme
                {
                    Id = 11,
                    IdProduit = 2,
                    IdVersion = 5,
                    IdSysteme = 5,
                    IdStatut = 1,
                    Date = new DateTime(2024, 12, 15),
                    Description = "Après rotation d’écran sur iPad, certains graphiques s’affichent mal ou leurs éléments sont mal repositionnés, " +
                        "altérant la lisibilité."
                },
                new Probleme
                {
                    Id = 12,
                    IdProduit = 2,
                    IdVersion = 6,
                    IdSysteme = 3,
                    IdStatut = 1,
                    Date = new DateTime(2025, 5, 5),
                    Description = "Lorsqu’un utilisateur importe un fichier contenant l’historique de ses transactions, certaines opérations apparaissent " +
                        "dans le désordre dans l’interface. Par exemple, une transaction du 12 janvier peut s’afficher avant une transaction du 10 janvier, " +
                        "ce qui rend la lecture de l’historique confuse."
                },
                new Probleme
                {
                    Id = 13,
                    IdProduit = 2,
                    IdVersion = 6,
                    IdSysteme = 4,
                    IdStatut = 1,
                    Date = new DateTime(2025, 5, 20),
                    Description = "Certaines alertes sont envoyées en double à des utilisateurs, générant des notifications redondantes et du bruit."
                },
                new Probleme
                {
                    Id = 14,
                    IdProduit = 2,
                    IdVersion = 6,
                    IdSysteme = 5,
                    IdStatut = 2,
                    Date = new DateTime(2025, 6, 1),
                    Description = "L’export CSV des transactions tronque les décimales sur certaines machines, entraînant des montants incorrects dans " +
                        "le fichier exporté."
                },
                new Probleme
                {
                    Id = 15,
                    IdProduit = 3,
                    IdVersion = 1,
                    IdSysteme = 1,
                    IdStatut = 2,
                    Date = new DateTime(2024, 8, 10),
                    Description = "L’export PDF des plans d’entraînement perd la mise en page sur certaines distributions Linux, rendant le document illisible."
                },
                new Probleme
                {
                    Id = 16,
                    IdProduit = 3,
                    IdVersion = 2,
                    IdSysteme = 2,
                    IdStatut = 1,
                    Date = new DateTime(2024, 11, 5),
                    Description = "Les rappels créés depuis l’application ne se matérialisent pas systématiquement dans l’application Calendrier MacOS " +
                        "pour certains comptes iCloud."
                },
                new Probleme
                {
                    Id = 17,
                    IdProduit = 3,
                    IdVersion = 2,
                    IdSysteme = 3,
                    IdStatut = 1,
                    Date = new DateTime(2024, 11, 12),
                    Description = "L’export CSV des séances contient des lignes dupliquées pour les utilisateurs situés dans des fuseaux horaires non UTC, " +
                        "faussant les rapports."
                },
                new Probleme
                {
                    Id = 18,
                    IdProduit = 3,
                    IdVersion = 2,
                    IdSysteme = 6,
                    IdStatut = 2,
                    Date = new DateTime(2024, 11, 20),
                    Description = "Les préférences utilisateur ne sont pas sauvegardées après redémarrage de l’application, obligeant les utilisateurs " +
                        "à reconfigurer leurs paramètres."
                },
                new Probleme
                {
                    Id = 19,
                    IdProduit = 3,
                    IdVersion = 1,
                    IdSysteme = 2,
                    IdStatut = 1,
                    Date = new DateTime(2025, 2, 15),
                    Description = "La synchronisation Bluetooth avec certains capteurs se coupe après 10–15 minutes, interrompant les sessions de suivi."
                },
                new Probleme
                {
                    Id = 20,
                    IdProduit = 3,
                    IdVersion = 5,
                    IdSysteme = 5,
                    IdStatut = 1,
                    Date = new DateTime(2025, 2, 28),
                    Description = "Les mesures cardio en session live sont affichées avec une latence de 5–10 secondes, ce qui nuit à l’expérience en temps réel."
                },
                new Probleme
                {
                    Id = 21,
                    IdProduit = 4,
                    IdVersion = 1,
                    IdSysteme = 3,
                    IdStatut = 2,
                    Date = new DateTime(2025, 3, 10),
                    Description = "Les exercices audio guidés se coupent prématurément sur certains PC, interrompant l’écoute des utilisateurs."
                },
                new Probleme
                {
                    Id = 22,
                    IdProduit = 4,
                    IdVersion = 1,
                    IdSysteme = 4,
                    IdStatut = 2,
                    Date = new DateTime(2025, 3, 15),
                    Description = "Les notifications arrivent sans son malgré des réglages sonores activés, ce qui fait manquer des rappels aux utilisateurs."
                },
                new Probleme
                {
                    Id = 23,
                    IdProduit = 4,
                    IdVersion = 1,
                    IdSysteme = 5,
                    IdStatut = 1,
                    Date = new DateTime(2025, 4, 20),
                    Description = "Le mode sombre n’est pas appliqué sur certaines vues de l’application, entraînant une incohérence visuelle."
                },
                new Probleme
                {
                    Id = 24,
                    IdProduit = 4,
                    IdVersion = 2,
                    IdSysteme = 2,
                    IdStatut = 1,
                    Date = new DateTime(2025, 9, 10),
                    Description = "L’export des journaux d’humeur laisse apparaître des métadonnées non anonymisées dans certains champs, " +
                        "posant un risque de non‑conformité RGPD."
                },
                new Probleme
                {
                    Id = 25,
                    IdProduit = 4,
                    IdVersion = 2,
                    IdSysteme = 3,
                    IdStatut = 2,
                    Date = new DateTime(2025, 10, 20),
                    Description = "Les sessions de suivi supérieures à deux heures ne sont pas correctement enregistrées, entraînant une perte " +
                        "de données pour les longues sessions."
                }
            );

            modelBuilder.Entity<Resolution>().HasData(
                new Resolution
                {
                    Id = 1,
                    IdProbleme = 1,
                    Date = new DateTime(2024, 3, 1),
                    Description = "Correction de la manière dont l’application sauvegarde les données avant de se fermer. Ajout d’une vérification " +
                        "au démarrage pour s’assurer que les informations affichées correspondent bien à celles enregistrées. Ainsi, le solde reste " +
                        "correct même après un redémarrage."
                },
                new Resolution
                {
                    Id = 2,
                    IdProbleme = 2,
                    Date = new DateTime(2024, 4, 25),
                    Description = "Modification du chargement des données pour que l’application n’essaie plus d’afficher tout d’un coup. " +
                        "Elle charge maintenant les informations petit à petit, ce qui évite les blocages et rend l’interface fluide."
                },
                new Resolution
                {
                    Id = 3,
                    IdProbleme = 3,
                    Date = new DateTime(2024, 7, 20),
                    Description = "Correction de la manière dont l’application envoie les informations de connexion. Les caractères spéciaux sont " +
                        "maintenant correctement pris en compte, ce qui permet à tous les utilisateurs de se connecter normalement."
                },
                new Resolution
                {
                    Id = 4,
                    IdProbleme = 5,
                    Date = new DateTime(2024, 8, 5),
                    Description = "Correction de la configuration du système de notifications et réinitialisation des paramètres liés aux " +
                        "notifications pour éviter les erreurs."
                },
                new Resolution
                {
                    Id = 5,
                    IdProbleme = 7,
                    Date = new DateTime(2025, 3, 10),
                    Description = "Réduction de la fréquence des tâches exécutées en arrière‑plan et optimisation de la manière dont l’application " +
                        "récupère les informations. Cela diminue fortement la consommation de la batterie."
                },
                new Resolution
                {
                    Id = 6,
                    IdProbleme = 9,
                    Date = new DateTime(2024, 6, 20),
                    Description = "Optimisation de la recherche en améliorant la manière dont les données sont récupérées. Les résultats s’affichent " +
                        "maintenant beaucoup plus rapidement, même avec de gros volumes."
                },
                new Resolution
                {
                    Id = 7,
                    IdProbleme = 10,
                    Date = new DateTime(2024, 12, 2),
                    Description = "Réduction de la quantité de données chargées d’un seul coup pour éviter que l’application ne dépasse la mémoire disponible. " +
                        "Le graphique s’ouvre maintenant sans faire planter l’application."
                },
                new Resolution
                {
                    Id = 8,
                    IdProbleme = 14,
                    Date = new DateTime(2025, 6, 20),
                    Description = "Correction du format d’export pour que les montants conservent toujours leurs décimales, peu importe la " +
                        "configuration de l’ordinateur. Les fichiers CSV sont maintenant fiables."
                },
                new Resolution
                {
                    Id = 9,
                    IdProbleme = 15,
                    Date = new DateTime(2024, 8, 30),
                    Description = "Mise à jour de la bibliothèque de génération PDF et ajustement de la mise en page pour qu’elle reste correcte " +
                        "sur toutes les distributions Linux. Les documents exportés sont maintenant lisibles."
                },
                new Resolution
                {
                    Id = 10,
                    IdProbleme = 18,
                    Date = new DateTime(2024, 12, 10),
                    Description = "Correction de l’enregistrement des préférences pour qu’elles soient bien conservées après la fermeture de " +
                        "l’application. Les utilisateurs n’ont plus besoin de reconfigurer leurs paramètres."
                },
                new Resolution
                {
                    Id = 11,
                    IdProbleme = 21,
                    Date = new DateTime(2025, 4, 1),
                    Description = "Amélioration de la gestion de la lecture audio pour éviter les coupures. Les exercices peuvent maintenant " +
                        "être écoutés jusqu’au bout sans interruption."
                },
                new Resolution
                {
                    Id = 12,
                    IdProbleme = 22,
                    Date = new DateTime(2025, 4, 5),
                    Description = "Correction des réglages des notifications pour que le son soit bien activé. Les utilisateurs entendent " +
                        "maintenant leurs alertes normalement."
                },
                new Resolution
                {
                    Id = 13,
                    IdProbleme = 25,
                    Date = new DateTime(2025, 10, 20),
                    Description = "Correction de la manière dont les longues sessions sont sauvegardées pour éviter les pertes de données. " +
                        "Les sessions de plus de deux heures sont maintenant enregistrées correctement."
                }
            );
        }
    }
}
