using ProductCatalogAPI.Application.Contracts;
using ProductCatalogAPI.Domain.Entities;
using ProductCatalogAPI.Infrastructure.DatabaseContext;

namespace ProductCatalogAPI.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ProductCatalogContext productCatalogContext) : base(productCatalogContext)
    {
    }
}
