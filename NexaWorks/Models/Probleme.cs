using System.ComponentModel.DataAnnotations;

namespace NexaWorks.Models
{
    public class Probleme
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string Description { get; set; }


        public int IdProduit { get; set; }
        public Produit? Produit { get; set; }

        public int IdVersion { get; set; }
        public Version? Version { get; set; }

        public int IdSysteme { get; set; }
        public Systeme? Systeme { get; set; }

        public int IdStatut { get; set; }
        public Statut? Statut { get; set; }

        public Resolution? Resolution { get; set; }
    }
}
