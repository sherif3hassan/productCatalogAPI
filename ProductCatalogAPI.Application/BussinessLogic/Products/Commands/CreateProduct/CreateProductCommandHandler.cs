using MediatR;
using ProductCatalogAPI.Application.Contracts;
using ProductCatalogAPI.Application.Contracts.Logging;
using ProductCatalogAPI.Application.Exceptions;
using ProductCatalogAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Application.BussinessLogic.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _productRepository;
    private readonly IAppLogger<CreateProductCommandHandler> _logger;

    public CreateProductCommandHandler(IProductRepository productRepository, IAppLogger<CreateProductCommandHandler> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
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
