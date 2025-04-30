namespace ProductCatalogAPI.Application.BussinessLogic.Products.DTOs;

public class ProductRequestDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }

    public ProductRequestDto(string name, string description, decimal price, string imageUrl)
    {
        Name = name;
        Description = description;
        Price = price;
        ImageUrl = imageUrl;
    }
}