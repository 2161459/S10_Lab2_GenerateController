using GenerationControleurs.Models;
using LinqEtSeedEF.Models;


//Ce code suppose que tes modèles utilisent les propriétés de navigation Commandes, 
//CommandePlats, Plat et Plats. Il faudra adapter leurs noms si tes classes sont différentes.
namespace GenerationControleurs.ViewModels
{
    public class RestaurantStatsVM
    {
        public RestaurantStatsVM(Restaurant restaurant)
        {
            Nom = restaurant.Nom;

            NbCommandes = restaurant.Commandes.Count();

            NbPlatsVendus = restaurant.Commandes
                .SelectMany(c => c.CommandesPlats)
                .Sum(cp => cp.Quantite);

            PrixTotalCommandes = restaurant.Commandes
                .SelectMany(c => c.CommandesPlats)
                .Sum(cp => cp.Quantite * cp.Plat.Prix);

            PrixMaxCommande = restaurant.Commandes
                .Select(c => c.CommandesPlats
                    .Sum(cp => cp.Quantite * cp.Plat.Prix))
                .DefaultIfEmpty(0)
                .Max();

            //MaxNiveauPiquant = restaurant.Plats
            //    .Max(p => p.NiveauPiquant) ?? 0;
            MaxNiveauPiquant = restaurant.Plats
                .Select(p => p.NiveauPiquant)
                .DefaultIfEmpty()
                .Max() ?? 0;
        }

        public string Nom { get; set; }
        public int NbCommandes { get; set; }
        public int NbPlatsVendus { get; set; }
        public decimal PrixTotalCommandes { get; set; }
        public decimal PrixMaxCommande { get; set; }
        public int MaxNiveauPiquant { get; set; }
    }
}