using ProductCatalogAPI.Domain.Entities;

namespace ProductCatalogAPI.Application.BussinessLogic.Products.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ProductDTO(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
        }
    }
}
