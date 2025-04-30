using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Identity.Models;

namespace ProductCatalogAPI.Identity.DbContext;

public class ProductCatalogIdentityContext : IdentityDbContext<ApplicationUser>
{
    public ProductCatalogIdentityContext(DbContextOptions<ProductCatalogIdentityContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ProductCatalogIdentityContext).Assembly);
    }
}
