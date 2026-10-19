using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LinqEtSeedEF.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }

        [ValidateNever] //ajouter //empêche ASP.NET Core de valider les propriétés de navigation lors de la soumission du formulaire.
        public List<Commande> Commandes { get; set; } = new(); //= new(); : initialise les listes pour éviter qu'elles soient null.

        [ValidateNever] //ajouter
        public List<Plat> Plats { get; set; } = new();
    }
}
