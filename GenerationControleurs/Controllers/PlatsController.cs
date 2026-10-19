
using LinqEtSeedEF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class PlatsController : Controller
{
    private readonly GenerationControleursContext _context;

    public PlatsController(GenerationControleursContext context)
    {
        _context = context;
    }

    // GET: PLATS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Plat.ToListAsync());
    }

    // GET: PLATS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var plat = await _context.Plat
            .FirstOrDefaultAsync(m => m.Id == id);
        if (plat == null)
        {
            return NotFound();
        }

        return View(plat);
    }

    // GET: PLATS/Create
    public IActionResult Create()
    {
        //Ajouter pour creation des plats
        ViewData["RestaurantId"] =
         new SelectList(_context.Restaurant, "Id", "Nom");

        return View();
    }

    // POST: PLATS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Create([Bind("Id,Nom,Description,Prix,NiveauPiquant,RestaurantId,Vegetarien,Restaurant,CommandesPlats")] Plat plat)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        _context.Add(plat);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }
    //    return View(plat);
    //}

    //Pour que le create d eplat fonctionne
    //enlevé Restaurant, CommandesPlats du Bind
    //ajouté le ViewData avant le dernier return
    //il faut également ajouter [ValidateNever] aux propriétés de navigation concernées dans Plat.cs.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
    [Bind("Id,Nom,Description,Prix,NiveauPiquant,RestaurantId,Vegetarien")] Plat plat)
    {
        if (ModelState.IsValid)
        {
            _context.Add(plat);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        ViewData["RestaurantId"] =
            new SelectList(_context.Restaurant, "Id", "Nom", plat.RestaurantId);

        return View(plat);
    }

    // GET: PLATS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var plat = await _context.Plat.FindAsync(id);
        if (plat == null)
        {
            return NotFound();
        }
        return View(plat);
    }

    // POST: PLATS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nom,Description,Prix,NiveauPiquant,RestaurantId,Vegetarien,Restaurant,CommandesPlats")] Plat plat)
    {
        if (id != plat.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(plat);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatExists(plat.Id))
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
        return View(plat);
    }

    // GET: PLATS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var plat = await _context.Plat
            .FirstOrDefaultAsync(m => m.Id == id);
        if (plat == null)
        {
            return NotFound();
        }

        return View(plat);
    }

    // POST: PLATS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var plat = await _context.Plat.FindAsync(id);
        if (plat != null)
        {
            _context.Plat.Remove(plat);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PlatExists(int? id)
    {
        return _context.Plat.Any(e => e.Id == id);
    }
}
