using LinqEtSeedEF.Models;
using Microsoft.EntityFrameworkCore;

public class GenerationControleursContext(DbContextOptions<GenerationControleursContext> options) : DbContext(options)
{
    public DbSet<LinqEtSeedEF.Models.Restaurant> Restaurant { get; set; } = default!;

    public DbSet<LinqEtSeedEF.Models.Plat> Plat { get; set; } = default!;  //Ajouter plat afin que entityframework les gere



    // AJOUTE LA MÉTHODE ICI (AJOUT D’UNE VUE DE STATISTIQUES 1)
    //Ensuite creer le dossier Viewmodel et les VM
    //Creer Controller Stats
    //Creer la vire Stats
    //_viewimport ajouter using
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // AJOUTE TES DONNÉES SEED ICI

        builder.Entity<Client>().HasData(
     new Client { Id = 1, Nom = "Marie-Josée Tremblay", Adresse = "123 rue Principale, Montréal", Telephone = "(514) 555-1234" },
     new Client { Id = 2, Nom = "Patrick Gagné", Adresse = "456 boulevard Saint-Laurent, Québec", Telephone = "(418) 555-5678" },
     new Client { Id = 3, Nom = "Sophie Dubois", Adresse = "789 avenue des Érables, Trois-Rivières", Telephone = "(819) 555-9012" },
     new Client { Id = 4, Nom = "Jean-François Lavoie", Adresse = "1010 rue Saint-Denis, Montréal", Telephone = "(514) 555-3456" },
     new Client { Id = 5, Nom = "Geneviève Parent", Adresse = "111 rue des Pionniers, Québec", Telephone = "(418) 555-7890" }
 );

        builder.Entity<Restaurant>().HasData(
            new Restaurant { Id = 1, Nom = "La graine du père George", Adresse = "456 rue Boyer, Montréal", Telephone = "(514) 555-2345" },
            new Restaurant { Id = 2, Nom = "Le Bistro", Adresse = "789 rue Principale, Québec", Telephone = "(418) 555-6789" },
            new Restaurant { Id = 3, Nom = "La Belle Province", Adresse = "1010 Pie IX, Trois-Rivières", Telephone = "(819) 555-2345" },
            new Restaurant { Id = 4, Nom = "La Piazzetta", Adresse = "1111 rue de la Montagne, Montréal", Telephone = "(514) 555-6789" }
        );

        builder.Entity<Plat>().HasData(
            new Plat { Id = 1, Nom = "Sauté de légumes", Description = "Un mélange de légumes frais sautés à la poêle", Prix = 8.99m, RestaurantId = 1, Vegetarien = true },
            new Plat { Id = 2, Nom = "Riz aux carottes", Description = "Du riz blanc servi avec des carottes fraîches", Prix = 6.99m, RestaurantId = 1, Vegetarien = true },
            new Plat { Id = 3, Nom = "Poulet au gingembre", Description = "Un délicieux plat de poulet avec du gingembre frais", Prix = 12.99m, RestaurantId = 2, Vegetarien = false, NiveauPiquant = 1 },
            new Plat { Id = 4, Nom = "Tofu au gingembre", Description = "Un délicieux plat de tofu avec du gingembre frais", Prix = 11.99m, RestaurantId = 2, Vegetarien = true, NiveauPiquant = 2 },
            new Plat { Id = 5, Nom = "Poutine", Description = "Patate, sauce, fromage skwich skwich", Prix = 7.99m, RestaurantId = 3, Vegetarien = false },
            new Plat { Id = 6, Nom = "Pizza", Description = "Pepperonni fromage", Prix = 9.99m, RestaurantId = 4, Vegetarien = false }
        );

        builder.Entity<Commande>().HasData(
            new Commande { Id = 1, Date = new DateTime(2022, 05, 01), ClientId = 1, RestaurantId = 1 },
            new Commande { Id = 2, Date = new DateTime(2022, 05, 02), ClientId = 2, RestaurantId = 2 },
            new Commande { Id = 3, Date = new DateTime(2022, 05, 03), ClientId = 3, RestaurantId = 3 },
            new Commande { Id = 4, Date = new DateTime(2022, 05, 03), ClientId = 2, RestaurantId = 4 },
            new Commande { Id = 5, Date = new DateTime(2022, 05, 04), ClientId = 2, RestaurantId = 2 }
        );

        builder.Entity<CommandePlat>().HasData(
            new CommandePlat { Id = 1, CommandeId = 1, PlatId = 1, Quantite = 1 },
            new CommandePlat { Id = 2, CommandeId = 1, PlatId = 2, Quantite = 2 },

            new CommandePlat { Id = 3, CommandeId = 2, PlatId = 3, Quantite = 1 },
            new CommandePlat { Id = 4, CommandeId = 2, PlatId = 4, Quantite = 1 },

            new CommandePlat { Id = 5, CommandeId = 3, PlatId = 5, Quantite = 4 },

            new CommandePlat { Id = 6, CommandeId = 4, PlatId = 6, Quantite = 2 },

            new CommandePlat { Id = 7, CommandeId = 5, PlatId = 3, Quantite = 3 },
            new CommandePlat { Id = 8, CommandeId = 5, PlatId = 4, Quantite = 3 }
        );

    }
}






