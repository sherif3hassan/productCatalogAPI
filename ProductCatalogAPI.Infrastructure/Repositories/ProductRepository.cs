using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using ProductCatalogAPI.Domain.Entities;
using ProductCatalogAPI.Application.Contracts;
using ProductCatalogAPI.Infrastructure.DatabaseContext;

namespace ProductCatalogAPI.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ProductCatalogContext productCatalogContext) : base(productCatalogContext)
    {
    }
}
