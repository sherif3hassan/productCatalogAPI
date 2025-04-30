using MediatR;

namespace ProductCatalogAPI.Application.BussinessLogic.Products.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
