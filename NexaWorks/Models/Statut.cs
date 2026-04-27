using System.ComponentModel.DataAnnotations;

namespace NexaWorks.Models
{
    public class Statut
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public ICollection<Probleme> Problemes { get; set; } = new List<Probleme>();
    }
}
