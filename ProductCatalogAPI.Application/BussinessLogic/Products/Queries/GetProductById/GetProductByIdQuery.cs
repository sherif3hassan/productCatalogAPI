using MediatR;
using ProductCatalogAPI.Application.BussinessLogic.Products.DTOs;

namespace ProductCatalogAPI.Application.BussinessLogic.Products.Queries.GetProductById;

public record GetProductByIdQuery(int Id) : IRequest<ProductDTO>;
