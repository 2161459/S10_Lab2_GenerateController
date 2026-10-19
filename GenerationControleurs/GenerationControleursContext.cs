using Microsoft.EntityFrameworkCore;

public class GenerationControleursContext(DbContextOptions<GenerationControleursContext> options) : DbContext(options)
{
    public DbSet<LinqEtSeedEF.Models.Restaurant> Restaurant { get; set; } = default!;

    public DbSet<LinqEtSeedEF.Models.Plat> Plat { get; set; } = default!;  //Ajouter plat afin que entityframework les gere
}
