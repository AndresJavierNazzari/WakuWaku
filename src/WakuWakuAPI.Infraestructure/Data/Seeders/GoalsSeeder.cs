using Microsoft.EntityFrameworkCore;

using WakuWakuAPI.Domain.Models;

namespace WakuWakuAPI.Infraestructure.Data.Seeders;

public static class GoalsSeeder
{
    public static ModelBuilder SeedGoals(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Goal>().HasData(
            new Goal { Id = 1, Description = "Learn HTML", Deadline = DateTime.Now.AddDays(30), UserId = 1, SkillId = 1, DificultyId = 1, StatusId = 1 },
            new Goal { Id = 2, Description = "Learn CSS", Deadline = DateTime.Now.AddDays(30), UserId = 1, SkillId = 2, DificultyId = 1, StatusId = 1 },
            new Goal { Id = 3, Description = "Learn JavaScript", Deadline = DateTime.Now.AddDays(30), UserId = 1, SkillId = 3, DificultyId = 1, StatusId = 1 },
            new Goal { Id = 4, Description = "Learn React", Deadline = DateTime.Now.AddDays(30), UserId = 1, SkillId = 4, DificultyId = 1, StatusId = 1 },
            new Goal { Id = 5, Description = "Learn Angular", Deadline = DateTime.Now.AddDays(30), UserId = 1, SkillId = 5, DificultyId = 1, StatusId = 1 },
            new Goal { Id = 6, Description = "Learn Vue", Deadline = DateTime.Now.AddDays(30), UserId = 1, SkillId = 6, DificultyId = 1, StatusId = 1 },
            new Goal { Id = 7, Description = "Learn Node", Deadline = DateTime.Now.AddDays(30), UserId = 1, SkillId = 7, DificultyId = 1, StatusId = 1 }
            );
        return modelBuilder;
    }
}
