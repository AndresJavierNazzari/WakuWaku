using Microsoft.EntityFrameworkCore;

using WakuWakuAPI.Domain.Models;

namespace WakuWakuAPI.Infraestructure.Data.Seeders;

public static class SkillsSeeder
{
    public static ModelBuilder SeedSkills(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Skill>().HasData(
            new Skill { Id = 1, Name = "HTML", Description = "Programing language", CategoryId = 1 },
            new Skill { Id = 2, Name = "CSS", Description = "Programing language", CategoryId = 1 },
            new Skill { Id = 3, Name = "JavaScript", Description = "Programing language", CategoryId = 1 },
            new Skill { Id = 4, Name = "React", Description = "Library", CategoryId = 1 },
            new Skill { Id = 5, Name = "Angular", Description = "Framework", CategoryId = 1 },
            new Skill { Id = 6, Name = "Vue", Description = "Framework", CategoryId = 1 },
            new Skill { Id = 7, Name = "Node", Description = "Runtime environment", CategoryId = 2 },
            new Skill { Id = 8, Name = "Python", Description = "Programing language", CategoryId = 2 },
            new Skill { Id = 9, Name = "Ruby", Description = "Programing language", CategoryId = 2 },
            new Skill { Id = 10, Name = "Java", Description = "Programing language", CategoryId = 2 },
            new Skill { Id = 11, Name = "C#", Description = "Programing language", CategoryId = 2 },
            new Skill { Id = 12, Name = "PHP", Description = "Programing language", CategoryId = 2 },
            new Skill { Id = 13, Name = "Swift", Description = "Programing language", CategoryId = 3 },
            new Skill { Id = 14, Name = "Kotlin", Description = "Programing language", CategoryId = 3 },
            new Skill { Id = 15, Name = "Objective-C", Description = "Programing language", CategoryId = 3 },
            new Skill { Id = 16, Name = "Xamarin", Description = "Framework", CategoryId = 3 },
            new Skill { Id = 17, Name = "Flutter", Description = "Framework", CategoryId = 3 },
            new Skill { Id = 18, Name = "Ionic", Description = "Framework", CategoryId = 3 },
            new Skill { Id = 19, Name = "Docker", Description = "Containerization platform", CategoryId = 4 },
            new Skill { Id = 20, Name = "Kubernetes", Description = "Container orchestration platform", CategoryId = 4 },
            new Skill { Id = 21, Name = "Jenkins", Description = "Automation server", CategoryId = 4 },
            new Skill { Id = 22, Name = "GitLab", Description = "DevOps platform", CategoryId = 4 },
            new Skill { Id = 23, Name = "GitHub", Description = "DevOps platform", CategoryId = 4 },
            new Skill { Id = 24, Name = "Bitbucket", Description = "DevOps platform", CategoryId = 4 },
            new Skill { Id = 25, Name = "Python", Description = "Programing language", CategoryId = 5 },
            new Skill { Id = 26, Name = "R", Description = "Programing language", CategoryId = 5 },
            new Skill { Id = 27, Name = "Scala", Description = "Programing language", CategoryId = 5 },
            new Skill { Id = 28, Name = "Julia", Description = "Programing language", CategoryId = 5 },
            new Skill { Id = 29, Name = "Matlab", Description = "Programing language", CategoryId = 5 },
            new Skill { Id = 30, Name = "Photoshop", Description = "Design software", CategoryId = 6 }
            );
        return modelBuilder;
    }
}
