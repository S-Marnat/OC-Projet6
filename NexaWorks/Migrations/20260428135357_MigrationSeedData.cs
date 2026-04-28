using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NexaWorks.Migrations
{
    /// <inheritdoc />
    public partial class MigrationSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produits",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "Trader en Herbe" },
                    { 2, "Maître des Investissements" },
                    { 3, "Planificateur d'Entraînement" },
                    { 4, "Planificateur d'Anxiété Sociale" }
                });

            migrationBuilder.InsertData(
                table: "Statuts",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "En cours" },
                    { 2, "Résolu" }
                });

            migrationBuilder.InsertData(
                table: "Systemes",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "Linux" },
                    { 2, "MacOS" },
                    { 3, "Windows" },
                    { 4, "Android" },
                    { 5, "iOS" },
                    { 6, "Windows Mobile" }
                });

            migrationBuilder.InsertData(
                table: "Versions",
                columns: new[] { "Id", "Numero" },
                values: new object[,]
                {
                    { 1, "1.0" },
                    { 2, "1.1" },
                    { 3, "1.2" },
                    { 4, "1.3" },
                    { 5, "2.0" },
                    { 6, "2.1" }
                });

            migrationBuilder.InsertData(
                table: "Problemes",
                columns: new[] { "Id", "Date", "Description", "IdProduit", "IdStatut", "IdSysteme", "IdVersion" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "L’utilisateur signale que l’application affiche des soldes de portefeuille incohérents après la fermeture puis la réouverture de l’application : le solde affiché est parfois inférieur de plusieurs centaines d’euros par rapport au solde attendu.", 1, 2, 3, 1 },
                    { 2, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "L’interface se fige plusieurs secondes à l’ouverture d’un portefeuille contenant plus de 500 positions, rendant l’application non réactive.", 1, 2, 2, 2 },
                    { 3, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "La connexion OAuth échoue pour des comptes dont le nom d’utilisateur contient des caractères spéciaux, empêchant certains utilisateurs de se connecter.", 1, 2, 1, 3 },
                    { 4, new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "L’application se déconnecte de manière aléatoire après 30–45 minutes d’inactivité sur certains appareils, surtout ceux avec des politiques d’économie d’énergie agressives.", 1, 1, 4, 3 },
                    { 5, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Les notifications push ne sont pas reçues lorsque des événements critiques sont envoyés depuis le backend.", 1, 2, 6, 3 },
                    { 6, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorsqu’un acheteur tente d’ajouter plusieurs articles à son panier en utilisant le bouton « Ajouter au panier », l’application ne met pas toujours à jour le nombre d’articles affiché dans le panier bien que les articles soient bien ajoutés en arrière‑plan, provoquant des erreurs d’achat.", 1, 1, 2, 4 },
                    { 7, new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "L’application consomme excessivement la batterie en arrière‑plan, ce qui provoque des retours négatifs des utilisateurs.", 1, 2, 4, 4 },
                    { 8, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Les favoris ajoutés sur un appareil iOS ne se synchronisent pas systématiquement sur les autres appareils de l’utilisateur, entraînant des pertes de favoris.", 1, 1, 5, 4 },
                    { 9, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Les recherches de titres sont lentes et provoquent des timeouts sur des catalogues volumineux, rendant la fonctionnalité peu utilisable.", 2, 2, 2, 1 },
                    { 10, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "L’application se ferme immédiatement lorsque l’utilisateur tente d’ouvrir un graphique montrant l’évolution d’une action sur plusieurs mois contenant un très grand nombre de points de données.", 2, 2, 4, 5 },
                    { 11, new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Après rotation d’écran sur iPad, certains graphiques s’affichent mal ou leurs éléments sont mal repositionnés, altérant la lisibilité.", 2, 1, 5, 5 },
                    { 12, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorsqu’un utilisateur importe un fichier contenant l’historique de ses transactions, certaines opérations apparaissent dans le désordre dans l’interface. Par exemple, une transaction du 12 janvier peut s’afficher avant une transaction du 10 janvier, ce qui rend la lecture de l’historique confuse.", 2, 1, 3, 6 },
                    { 13, new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Certaines alertes sont envoyées en double à des utilisateurs, générant des notifications redondantes et du bruit.", 2, 1, 4, 6 },
                    { 14, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "L’export CSV des transactions tronque les décimales sur certaines machines, entraînant des montants incorrects dans le fichier exporté.", 2, 2, 5, 6 },
                    { 15, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "L’export PDF des plans d’entraînement perd la mise en page sur certaines distributions Linux, rendant le document illisible.", 3, 2, 1, 1 },
                    { 16, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Les rappels créés depuis l’application ne se matérialisent pas systématiquement dans l’application Calendrier MacOS pour certains comptes iCloud.", 3, 1, 2, 2 },
                    { 17, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "L’export CSV des séances contient des lignes dupliquées pour les utilisateurs situés dans des fuseaux horaires non UTC, faussant les rapports.", 3, 1, 3, 2 },
                    { 18, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Les préférences utilisateur ne sont pas sauvegardées après redémarrage de l’application, obligeant les utilisateurs à reconfigurer leurs paramètres.", 3, 2, 6, 2 },
                    { 19, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "La synchronisation Bluetooth avec certains capteurs se coupe après 10–15 minutes, interrompant les sessions de suivi.", 3, 1, 2, 1 },
                    { 20, new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Les mesures cardio en session live sont affichées avec une latence de 5–10 secondes, ce qui nuit à l’expérience en temps réel.", 3, 1, 5, 5 },
                    { 21, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Les exercices audio guidés se coupent prématurément sur certains PC, interrompant l’écoute des utilisateurs.", 4, 2, 3, 1 },
                    { 22, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Les notifications arrivent sans son malgré des réglages sonores activés, ce qui fait manquer des rappels aux utilisateurs.", 4, 2, 4, 1 },
                    { 23, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Le mode sombre n’est pas appliqué sur certaines vues de l’application, entraînant une incohérence visuelle.", 4, 1, 5, 1 },
                    { 24, new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "L’export des journaux d’humeur laisse apparaître des métadonnées non anonymisées dans certains champs, posant un risque de non‑conformité RGPD.", 4, 1, 2, 2 },
                    { 25, new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Les sessions de suivi supérieures à deux heures ne sont pas correctement enregistrées, entraînant une perte de données pour les longues sessions.", 4, 2, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProduitsVersionsSystemes",
                columns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 1, 3, 1 },
                    { 1, 1, 2 },
                    { 1, 2, 2 },
                    { 1, 3, 2 },
                    { 1, 1, 3 },
                    { 1, 2, 3 },
                    { 1, 3, 3 },
                    { 1, 4, 3 },
                    { 1, 5, 3 },
                    { 1, 6, 3 },
                    { 1, 2, 4 },
                    { 1, 3, 4 },
                    { 1, 4, 4 },
                    { 1, 5, 4 },
                    { 2, 2, 1 },
                    { 2, 5, 1 },
                    { 2, 2, 5 },
                    { 2, 4, 5 },
                    { 2, 5, 5 },
                    { 2, 2, 6 },
                    { 2, 3, 6 },
                    { 2, 4, 6 },
                    { 2, 5, 6 },
                    { 3, 1, 1 },
                    { 3, 2, 1 },
                    { 3, 1, 2 },
                    { 3, 2, 2 },
                    { 3, 3, 2 },
                    { 3, 4, 2 },
                    { 3, 5, 2 },
                    { 3, 6, 2 },
                    { 3, 2, 5 },
                    { 3, 3, 5 },
                    { 3, 4, 5 },
                    { 3, 5, 5 },
                    { 4, 2, 1 },
                    { 4, 3, 1 },
                    { 4, 4, 1 },
                    { 4, 5, 1 },
                    { 4, 2, 2 },
                    { 4, 3, 2 },
                    { 4, 4, 2 },
                    { 4, 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "Resolutions",
                columns: new[] { "Id", "Date", "Description", "IdProbleme" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Correction de la manière dont l’application sauvegarde les données avant de se fermer. Ajout d’une vérification au démarrage pour s’assurer que les informations affichées correspondent bien à celles enregistrées. Ainsi, le solde reste correct même après un redémarrage.", 1 },
                    { 2, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Modification du chargement des données pour que l’application n’essaie plus d’afficher tout d’un coup. Elle charge maintenant les informations petit à petit, ce qui évite les blocages et rend l’interface fluide.", 2 },
                    { 3, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Correction de la manière dont l’application envoie les informations de connexion. Les caractères spéciaux sont maintenant correctement pris en compte, ce qui permet à tous les utilisateurs de se connecter normalement.", 3 },
                    { 4, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Correction de la configuration du système de notifications et réinitialisation des paramètres liés aux notifications pour éviter les erreurs.", 5 },
                    { 5, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Réduction de la fréquence des tâches exécutées en arrière‑plan et optimisation de la manière dont l’application récupère les informations. Cela diminue fortement la consommation de la batterie.", 7 },
                    { 6, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Optimisation de la recherche en améliorant la manière dont les données sont récupérées. Les résultats s’affichent maintenant beaucoup plus rapidement, même avec de gros volumes.", 9 },
                    { 7, new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Réduction de la quantité de données chargées d’un seul coup pour éviter que l’application ne dépasse la mémoire disponible. Le graphique s’ouvre maintenant sans faire planter l’application.", 10 },
                    { 8, new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Correction du format d’export pour que les montants conservent toujours leurs décimales, peu importe la configuration de l’ordinateur. Les fichiers CSV sont maintenant fiables.", 14 },
                    { 9, new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mise à jour de la bibliothèque de génération PDF et ajustement de la mise en page pour qu’elle reste correcte sur toutes les distributions Linux. Les documents exportés sont maintenant lisibles.", 15 },
                    { 10, new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Correction de l’enregistrement des préférences pour qu’elles soient bien conservées après la fermeture de l’application. Les utilisateurs n’ont plus besoin de reconfigurer leurs paramètres.", 18 },
                    { 11, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amélioration de la gestion de la lecture audio pour éviter les coupures. Les exercices peuvent maintenant être écoutés jusqu’au bout sans interruption.", 21 },
                    { 12, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Correction des réglages des notifications pour que le son soit bien activé. Les utilisateurs entendent maintenant leurs alertes normalement.", 22 },
                    { 13, new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Correction de la manière dont les longues sessions sont sauvegardées pour éviter les pertes de données. Les sessions de plus de deux heures sont maintenant enregistrées correctement.", 25 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 1, 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 1, 3, 1 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 1, 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 1, 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 1, 3, 2 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 1, 1, 3 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 1, 2, 3 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 1, 3, 3 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 1, 4, 3 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 1, 5, 3 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 1, 6, 3 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 1, 2, 4 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 1, 3, 4 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 1, 4, 4 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 1, 5, 4 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 2, 2, 1 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 2, 5, 1 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 2, 2, 5 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 2, 4, 5 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 2, 5, 5 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 2, 2, 6 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 2, 3, 6 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 2, 4, 6 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 2, 5, 6 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 3, 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 3, 2, 1 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 3, 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 3, 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 3, 3, 2 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 3, 4, 2 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 3, 5, 2 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 3, 6, 2 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 3, 2, 5 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 3, 3, 5 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 3, 4, 5 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 3, 5, 5 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 4, 2, 1 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 4, 3, 1 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 4, 4, 1 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 4, 5, 1 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 4, 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 4, 3, 2 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 4, 4, 2 });

            migrationBuilder.DeleteData(
                table: "ProduitsVersionsSystemes",
                keyColumns: new[] { "IdProduit", "IdSysteme", "IdVersion" },
                keyValues: new object[] { 4, 5, 2 });

            migrationBuilder.DeleteData(
                table: "Resolutions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Resolutions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Resolutions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Resolutions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Resolutions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Resolutions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Resolutions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Resolutions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Resolutions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Resolutions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Resolutions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Resolutions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Resolutions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Problemes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Statuts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Statuts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Systemes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Systemes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Systemes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Systemes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Systemes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Systemes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Versions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Versions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Versions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Versions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Versions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Versions",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
