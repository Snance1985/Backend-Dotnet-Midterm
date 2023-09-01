using midterm_project.Models;
using Microsoft.EntityFrameworkCore;

namespace midterm_project.Migrations;

public class ShopDbContext : DbContext 
{
    public DbSet<Shop> Shop { get; set; }

    public ShopDbContext(DbContextOptions<ShopDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.HasKey(e => e.ShopId);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.ImgUrl).IsRequired();
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.TypeOfDino).IsRequired();
            entity.Property(e => e.Price).IsRequired();
        });
    }
}