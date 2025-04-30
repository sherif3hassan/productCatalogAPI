using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogAPI.Application.BussinessLogic.Products.Commands.CreateProduct;
using ProductCatalogAPI.Application.BussinessLogic.Products.Commands.DeleteProduct;
using ProductCatalogAPI.Application.BussinessLogic.Products.Commands.UpdateProduct;
using ProductCatalogAPI.Application.BussinessLogic.Products.DTOs;
using ProductCatalogAPI.Application.BussinessLogic.Products.Queries.GetProductById;
using ProductCatalogAPI.Application.BussinessLogic.Products.Queries.GetProducts;
using System.Threading.Tasks;


namespace ProductCatalogAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IReadOnlyList<ProductDTO>> Get()
        {
            var products = await _mediator.Send(new GetProductsQuery());

            return products;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ProductDTO> Get(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return product;
        }

        // POST api/<ProductsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(CreateProductCommand command)
        {
            var productId = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = productId }, null);
        }

        // PUT api/<ProductsController>/
  
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(UpdateProductCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
