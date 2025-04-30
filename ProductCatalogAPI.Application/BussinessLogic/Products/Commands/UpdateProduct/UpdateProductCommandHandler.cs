using MediatR;
using Microsoft.Extensions.Logging;
using ProductCatalogAPI.Application.Contracts;
using ProductCatalogAPI.Application.Exceptions;

namespace ProductCatalogAPI.Application.BussinessLogic.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<UpdateProductCommandHandler> _logger;

    public UpdateProductCommandHandler(
        IProductRepository productRepository,
        ILogger<UpdateProductCommandHandler> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating product with ID: {ProductId}", request.Id);

        var product = await _productRepository.GetByIdAsync(request.Id);
        if (product == null)
        {
            _logger.LogWarning("Product not found for update with ID: {ProductId}", request.Id);
            throw new NotFoundException("Product not found");
        }

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;

        await _productRepository.UpdateAsync(product);
        _logger.LogInformation("Successfully updated product with ID: {ProductId}", request.Id);
        return Unit.Value;
    }
}
