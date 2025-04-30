using MediatR;
using ProductCatalogAPI.Application.BussinessLogic.Products.DTOs;

namespace ProductCatalogAPI.Application.BussinessLogic.Products.Queries.GetProducts;

public record GetProductsQuery : IRequest<List<ProductDTO>>;