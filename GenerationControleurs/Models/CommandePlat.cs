using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace LinqEtSeedEF.Models
{
    public class CommandePlat
    {
        public int Id { get; set; }
        public int? PlatId { get; set; }
        public Plat? Plat { get; set; }
        public int? CommandeId { get; set; }
        public Commande? Commande { get; set; }

        public int Quantite { get; set; }
    }
}
