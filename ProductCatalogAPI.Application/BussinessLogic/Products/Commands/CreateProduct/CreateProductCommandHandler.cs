using MediatR;
using Microsoft.Extensions.Logging;
using ProductCatalogAPI.Application.Contracts;
using ProductCatalogAPI.Domain.Entities;

namespace ProductCatalogAPI.Application.BussinessLogic.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<CreateProductCommandHandler> _logger;

    public CreateProductCommandHandler(
        IProductRepository productRepository,
        ILogger<CreateProductCommandHandler> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new product with name: {ProductName}", request.Name);
        
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
        };

        await _productRepository.CreateAsync(product);
        _logger.LogInformation("Product created successfully with ID: {ProductId}", product.Id);
        return product.Id;
    }
}
