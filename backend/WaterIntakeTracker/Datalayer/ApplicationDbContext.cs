using Microsoft.EntityFrameworkCore;
using WaterIntakeTracker.DataLayer.Models;

namespace WaterIntakeTracker.DataLayer;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Test> TestModels { get; set; }
    public DbSet<Datalayer.Models.User> Users { get; set; }
}
