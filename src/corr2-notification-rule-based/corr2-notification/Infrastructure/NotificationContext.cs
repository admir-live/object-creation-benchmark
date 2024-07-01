using Corr2.Notification.PoC.Entities;
using Corr2.Notification.PoC.Infrastructure.Configurations;
using Corr2.Notification.PoC.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;

namespace Corr2.Notification.PoC.Infrastructure;

public class NotificationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<NotificationTemplate> NotificationTemplates { get; set; }
    public DbSet<NotificationCriteria> NotificationCriteria { get; set; }
    public DbSet<Result> Results { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("NotificationDatabase");
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new NotificationTemplateConfiguration());
        modelBuilder.ApplyConfiguration(new NotificationCriteriaConfiguration());
        modelBuilder.ApplyConfiguration(new ResultConfiguration());
    }

    public void EnsureSeedData()
    {
        Users.AddRange(SeedData.Users);
        SaveChanges();
    }
}
