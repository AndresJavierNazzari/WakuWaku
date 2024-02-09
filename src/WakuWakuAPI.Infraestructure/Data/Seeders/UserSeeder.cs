using Microsoft.EntityFrameworkCore;

using WakuWakuAPI.Domain.Models;

namespace WakuWakuAPI.Infraestructure.Data.Seeders;

public static class UserSeeder
{
    public static ModelBuilder SeedUsers(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, FirstName = "John", LastName = "Doe", UserDataId = 1 },
            new User { Id = 2, FirstName = "Jane", LastName = "Doe", UserDataId = 2 },
            new User { Id = 3, FirstName = "John", LastName = "Smith", UserDataId = 3 }
            );
        return modelBuilder;
    }
}
