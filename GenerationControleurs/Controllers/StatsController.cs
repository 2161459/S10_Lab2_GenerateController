using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GenerationControleurs.ViewModels;

namespace GenerationControleurs.Controllers
{
    public class StatsController : Controller
    {
        private readonly GenerationControleursContext _context;

        public StatsController(GenerationControleursContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var restaurants = await _context.Restaurant
                .Include(r => r.Plats)
                .Include(r => r.Commandes)
                    .ThenInclude(c => c.CommandesPlats)
                        .ThenInclude(cp => cp.Plat)
                .ToListAsync();

            RestaurantsStatsVM vm = new RestaurantsStatsVM(restaurants);

            return View(vm);
        }
    }
}