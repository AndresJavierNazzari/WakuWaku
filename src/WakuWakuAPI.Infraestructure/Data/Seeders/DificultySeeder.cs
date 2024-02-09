using Microsoft.EntityFrameworkCore;

using WakuWakuAPI.Domain.Models;

namespace WakuWakuAPI.Infraestructure.Data.Seeders;

public static class DificultySeeder
{
    public static ModelBuilder SeedDificulty(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dificulty>().HasData(
        new Dificulty { Id = 1, Description = "Easy" },
            new Dificulty { Id = 2, Description = "Medium" },
            new Dificulty { Id = 3, Description = "Hard" }
            );

        return modelBuilder;
    }
}
