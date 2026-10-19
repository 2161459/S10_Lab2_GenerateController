
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LinqEtSeedEF.Models;

public class RestaurantsController : Controller
{
    private readonly GenerationControleursContext _context;

    public RestaurantsController(GenerationControleursContext context)
    {
        _context = context;
    }

    // GET: RESTAURANTS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Restaurant.ToListAsync());
    }

    // GET: RESTAURANTS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var restaurant = await _context.Restaurant
            .FirstOrDefaultAsync(m => m.Id == id);
        if (restaurant == null)
        {
            return NotFound();
        }

        return View(restaurant);
    }

    // GET: RESTAURANTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: RESTAURANTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nom,Adresse,Telephone,Commandes,Plats")] Restaurant restaurant)
    {
        if (ModelState.IsValid)
        {
            _context.Add(restaurant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(restaurant);
    }

    // GET: RESTAURANTS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var restaurant = await _context.Restaurant.FindAsync(id);
        if (restaurant == null)
        {
            return NotFound();
        }
        return View(restaurant);
    }

    // POST: RESTAURANTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nom,Adresse,Telephone,Commandes,Plats")] Restaurant restaurant)
    {
        if (id != restaurant.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(restaurant);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(restaurant.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(restaurant);
    }

    // GET: RESTAURANTS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var restaurant = await _context.Restaurant
            .FirstOrDefaultAsync(m => m.Id == id);
        if (restaurant == null)
        {
            return NotFound();
        }

        return View(restaurant);
    }

    // POST: RESTAURANTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var restaurant = await _context.Restaurant.FindAsync(id);
        if (restaurant != null)
        {
            _context.Restaurant.Remove(restaurant);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool RestaurantExists(int? id)
    {
        return _context.Restaurant.Any(e => e.Id == id);
    }
}
