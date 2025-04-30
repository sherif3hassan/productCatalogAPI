using MediatR;
using ProductCatalogAPI.Application.BussinessLogic.Products.DTOs;
using ProductCatalogAPI.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Application.BussinessLogic.Products.Queries.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDTO>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsQueryHandler(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }
    public async Task<List<ProductDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        // Implementation of the query handler
        var products = await _productRepository.GetAllAsync();
        var productDTOs = products.Select(p => new ProductDTO(p)).ToList();
        //throw new NotImplementedException();
        return productDTOs;
    }
}