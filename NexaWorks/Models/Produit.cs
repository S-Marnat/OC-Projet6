using System.ComponentModel.DataAnnotations;

namespace NexaWorks.Models
{
    public class Produit
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public ICollection<ProduitVersion> ProduitsVersions { get; set; } = new List<ProduitVersion>();
        public ICollection<Probleme> Problemes { get; set; } = new List<Probleme>();
    }
}
