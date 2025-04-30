using MediatR;
using Microsoft.Extensions.Logging;
using ProductCatalogAPI.Application.Contracts;
using ProductCatalogAPI.Application.Exceptions;
using ProductCatalogAPI.Domain.Entities;

namespace ProductCatalogAPI.Application.BussinessLogic.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<DeleteProductCommandHandler> _logger;

    public DeleteProductCommandHandler(
        IProductRepository productRepository,
        ILogger<DeleteProductCommandHandler> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting product with ID: {ProductId}", request.Id);

        var product = await _productRepository.GetByIdAsync(request.Id);
        if (product == null)
        {
            _logger.LogWarning("Product not found for deletion with ID: {ProductId}", request.Id);
            throw new NotFoundException("Product not found");
        }

        await _productRepository.DeleteAsync(product);
        _logger.LogInformation("Successfully deleted product with ID: {ProductId}", request.Id);
        return Unit.Value;
    }
}
