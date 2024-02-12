using Microsoft.EntityFrameworkCore;

using WakuWakuAPI.Domain.Models;

namespace WakuWakuAPI.Infraestructure.Data.Seeders;

public static class CategoriesSeeder
{
    public static ModelBuilder SeedCategories(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Frontend", Description = "Some description" },
            new Category { Id = 2, Name = "Backend", Description = "Some description" },
            new Category { Id = 3, Name = "Mobile", Description = "Some description" },
            new Category { Id = 4, Name = "DevOps", Description = "Some description" },
            new Category { Id = 5, Name = "Data Science", Description = "Some description" },
            new Category { Id = 6, Name = "Design", Description = "Some description" }
            );

        return modelBuilder;
    }
}
