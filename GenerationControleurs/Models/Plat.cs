using Microsoft.AspNetCore.Mvc.ModelBinding.Validation; //Ajouter

namespace LinqEtSeedEF.Models
{
    public class Plat
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
        public int? NiveauPiquant { get; set; }
        public int RestaurantId { get; set; }
        public bool Vegetarien {  get; set; }

        [ValidateNever] //Ajouter
        public Restaurant? Restaurant { get; set; }

        [ValidateNever] //Ajouter
        public List<CommandePlat> CommandesPlats { get; set; } = new List<CommandePlat>(); //Ajouter
    }
}
