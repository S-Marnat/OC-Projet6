using System.ComponentModel.DataAnnotations;

namespace NexaWorks.Models
{
    public class ProduitVersionSysteme
    {
        public int IdProduit { get; set; }
        public Produit? Produit { get; set; }

        public int IdVersion { get; set; }
        public Version? Version { get; set; }

        public int IdSysteme { get; set; }
        public Systeme? Systeme { get; set; }
    }
}
