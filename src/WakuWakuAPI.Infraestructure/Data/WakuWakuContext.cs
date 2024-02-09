using Microsoft.EntityFrameworkCore;

using WakuWakuAPI.Domain.Models;

namespace WakuWakuAPI.Infraestructure.Data;

public class WakuWakuContext : DbContext
{
    public WakuWakuContext(DbContextOptions<WakuWakuContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Goal> Goals { get; set; }
    public DbSet<Skill> Skills { get; set; }



}
