using FluentValidation;

namespace ProductCatalogAPI.Application.BussinessLogic.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Product name is required.")
            .NotNull().MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");

        RuleFor(x => x.Description).NotEmpty().WithMessage("Product description is required.")
            .NotNull().MaximumLength(500).WithMessage("Product description must not exceed 500 characters.");

        RuleFor(x => x.Price).NotEmpty().WithMessage("Product price is required.")
            .NotNull().GreaterThan(0).WithMessage("Product price must be greater than 0.");
    }
}
