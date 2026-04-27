using System.ComponentModel.DataAnnotations;

namespace NexaWorks.Models
{
    public class Version
    {
        public int Id { get; set; }

        public string Numero { get; set; }

        public ICollection<ProduitVersion> ProduitsVersions { get; set; } = new List<ProduitVersion>();
        public ICollection<Probleme> Problemes { get; set; } = new List<Probleme>();
    }
}
