using Microsoft.EntityFrameworkCore;

using WakuWakuAPI.Domain.Models;

namespace WakuWakuAPI.Infraestructure.Data.Seeders;

public static class UserDataSeeder
{
    public static ModelBuilder SeedUsersData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserData>().HasData(
            new UserData { Id = 1, Email = "email1@email.com", Password = "password1" },
            new UserData { Id = 2, Email = "email2@email.com", Password = "password2" },
            new UserData { Id = 3, Email = "email3@email.com", Password = "password3" }
            );
        return modelBuilder;
    }
}
