using GenerationControleurs.Models;
using LinqEtSeedEF.Models;

namespace GenerationControleurs.ViewModels
{
    public class RestaurantsStatsVM
    {
        public RestaurantsStatsVM(IEnumerable<Restaurant> restaurants)
        {
            RestaurantStatsVM = restaurants
                .Select(r => new RestaurantStatsVM(r))
                .ToList();

            NbCommandes = RestaurantStatsVM.Sum(r => r.NbCommandes);

            NbPlatsVendus = RestaurantStatsVM.Sum(r => r.NbPlatsVendus);

            PrixTotalCommandes = RestaurantStatsVM.Sum(r => r.PrixTotalCommandes);

            PrixMaxCommande = RestaurantStatsVM
                .Select(r => r.PrixMaxCommande)
                .DefaultIfEmpty(0)
                .Max();

            MaxNiveauPiquant = RestaurantStatsVM
                .Select(r => r.MaxNiveauPiquant)
                .DefaultIfEmpty(0)
                .Max();
        }

        public int NbCommandes { get; set; }
        public int NbPlatsVendus { get; set; }
        public decimal PrixTotalCommandes { get; set; }
        public decimal PrixMaxCommande { get; set; }
        public int MaxNiveauPiquant { get; set; }

        public IEnumerable<RestaurantStatsVM> RestaurantStatsVM { get; set; }
    }
}