using Microsoft.EntityFrameworkCore;

public class GenerationControleursContext(DbContextOptions<GenerationControleursContext> options) : DbContext(options)
{
    public DbSet<LinqEtSeedEF.Models.Restaurant> Restaurant { get; set; } = default!;
}
