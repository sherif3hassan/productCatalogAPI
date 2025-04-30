using MediatR;

namespace ProductCatalogAPI.Application.BussinessLogic.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}
