using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Domain.Entities;

namespace ProductCatalogAPI.Infrastructure.DatabaseContext;

public class ProductCatalogContext : DbContext
{
    public ProductCatalogContext(DbContextOptions<ProductCatalogContext> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetAuditableEntityProperties();
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductCatalogContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    private void SetAuditableEntityProperties()
    {
        var entries = ChangeTracker.Entries<BaseEntity>();
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.ModifiedAt = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.ModifiedAt = DateTime.UtcNow;
            }
        }
    }
}