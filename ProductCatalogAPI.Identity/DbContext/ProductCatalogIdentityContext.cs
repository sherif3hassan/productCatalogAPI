using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
