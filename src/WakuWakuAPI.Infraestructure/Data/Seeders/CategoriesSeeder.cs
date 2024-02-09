using Microsoft.EntityFrameworkCore;

using WakuWakuAPI.Domain.Models;

namespace WakuWakuAPI.Infraestructure.Data.Seeders;

public static class CategoriesSeeder
{
    public static ModelBuilder SeedCategories(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Description = "Frontend" },
            new Category { Id = 2, Description = "Backend" },
            new Category { Id = 3, Description = "Mobile" },
            new Category { Id = 4, Description = "DevOps" },
            new Category { Id = 5, Description = "Data Science" },
            new Category { Id = 6, Description = "Design" }
            );

        return modelBuilder;
    }
}
