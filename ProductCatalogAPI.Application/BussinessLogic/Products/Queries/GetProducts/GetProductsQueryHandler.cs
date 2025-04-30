using MediatR;
using Microsoft.Extensions.Logging;
using ProductCatalogAPI.Application.BussinessLogic.Products.DTOs;
using ProductCatalogAPI.Application.Contracts;

namespace ProductCatalogAPI.Application.BussinessLogic.Products.Queries.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDTO>>
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<GetProductsQueryHandler> _logger;

    public GetProductsQueryHandler(
        IProductRepository productRepository,
        ILogger<GetProductsQueryHandler> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }
    public async Task<List<ProductDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving all products");

        var products = await _productRepository.GetAllAsync();
        var productDTOs = products.Select(p => new ProductDTO(p)).ToList();

        _logger.LogInformation("Retrieved {Count} products", productDTOs.Count);
        return productDTOs;
    }
}