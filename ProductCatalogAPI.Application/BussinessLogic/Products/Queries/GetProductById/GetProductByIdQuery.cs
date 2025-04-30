using MediatR;
using ProductCatalogAPI.Application.BussinessLogic.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Application.BussinessLogic.Products.Queries.GetProductById;

public record GetProductByIdQuery(int Id) : IRequest<ProductDTO>;
