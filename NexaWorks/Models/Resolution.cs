using System.ComponentModel.DataAnnotations;

namespace NexaWorks.Models
{
    public class Resolution
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string Description { get; set; }

        public int IdProbleme { get; set; }
        public Probleme? Probleme { get; set; }
    }
}
