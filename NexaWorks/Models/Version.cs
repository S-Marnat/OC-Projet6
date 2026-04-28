using System.ComponentModel.DataAnnotations;

namespace NexaWorks.Models
{
    public class Version
    {
        public int Id { get; set; }

        public string Numero { get; set; }

        public ICollection<ProduitVersionSysteme> ProduitsVersionsSystemes { get; set; } = new List<ProduitVersionSysteme>();
        public ICollection<Probleme> Problemes { get; set; } = new List<Probleme>();
    }
}
