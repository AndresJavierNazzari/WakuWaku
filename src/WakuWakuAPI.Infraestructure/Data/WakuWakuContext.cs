﻿using Microsoft.EntityFrameworkCore;

using WakuWakuAPI.Domain.Models;
using WakuWakuAPI.Infraestructure.Data.Seeders;

namespace WakuWakuAPI.Infraestructure.Data;

public class WakuWakuContext : DbContext
{
    public WakuWakuContext(DbContextOptions<WakuWakuContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<UserData> UsersData { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<Dificulty> Dificulty { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Goal> Goals { get; set; }
    public DbSet<Skill> Skills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Relation between Category and Skill
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Skills)
            .WithOne(s => s.Category)
            .HasForeignKey(s => s.CategoryId);

        //Relation between Skill and Goal
        modelBuilder.Entity<Skill>()
            .HasMany(s => s.Goals)
            .WithOne(g => g.Skill)
            .HasForeignKey(g => g.SkillId);

        //Relation between Dificulty and Goal
        modelBuilder.Entity<Dificulty>()
            .HasMany(d => d.Goals)
            .WithOne(g => g.Dificulty)
            .HasForeignKey(g => g.DificultyId);

        //Relation between Status and Goal
        modelBuilder.Entity<Status>()
            .HasMany(s => s.Goals)
            .WithOne(g => g.Status)
            .HasForeignKey(g => g.StatusId);

        //Relation between User and Goal
        modelBuilder.Entity<User>()
            .HasMany(u => u.Goals)
            .WithOne(g => g.User)
            .HasForeignKey(g => g.UserId);

        //Relation between User and UserData
        modelBuilder.Entity<User>()
            .HasOne(u => u.UserData)
            .WithOne()
            .HasForeignKey<User>(u => u.UserDataId);

        //Seeders
        modelBuilder.SeedDificulty();
        modelBuilder.SeedStatus();
        modelBuilder.SeedCategories();
        modelBuilder.SeedSkills();
        modelBuilder.SeedUsersData();
        modelBuilder.SeedUsers();
        modelBuilder.SeedGoals();
    }

}
