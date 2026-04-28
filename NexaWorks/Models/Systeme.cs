using System.ComponentModel.DataAnnotations;

namespace NexaWorks.Models
{
    public class Systeme
    {
        public int Id { get; set; }

        public string Nom {  get; set; }

        public ICollection<ProduitVersionSysteme> ProduitsVersionsSystemes { get; set; } = new List<ProduitVersionSysteme>();
        public ICollection<Probleme> Problemes { get; set; } = new List<Probleme>();
    }
}
