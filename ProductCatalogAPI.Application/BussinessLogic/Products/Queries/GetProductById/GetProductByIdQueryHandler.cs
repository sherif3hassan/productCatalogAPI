using MediatR;
using Microsoft.Extensions.Logging;
using ProductCatalogAPI.Application.BussinessLogic.Products.DTOs;
using ProductCatalogAPI.Application.Contracts;
using ProductCatalogAPI.Application.Exceptions;

namespace ProductCatalogAPI.Application.BussinessLogic.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDTO>
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<GetProductByIdQueryHandler> _logger;

    public GetProductByIdQueryHandler(
        IProductRepository productRepository,
        ILogger<GetProductByIdQueryHandler> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting product with ID: {ProductId}", request.Id);

        var product = await _productRepository.GetByIdAsync(request.Id);
        if (product == null)
            throw new NotFoundException("Product not found");

        var productDTO = new ProductDTO(product);
        _logger.LogInformation("Retrieved product: {ProductId}", product.Id);
        return productDTO;
    }
}
