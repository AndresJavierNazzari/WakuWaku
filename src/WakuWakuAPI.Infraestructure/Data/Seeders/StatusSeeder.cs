using Microsoft.EntityFrameworkCore;

using WakuWakuAPI.Domain.Models;

namespace WakuWakuAPI.Infraestructure.Data.Seeders;

public static class StatusSeeder
{
    public static ModelBuilder SeedStatus(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Status>().HasData(
            new Status { Id = 1, Description = "To Do" },
            new Status { Id = 2, Description = "In Progress" },
            new Status { Id = 3, Description = "Done" }
            );

        return modelBuilder;
    }
}
