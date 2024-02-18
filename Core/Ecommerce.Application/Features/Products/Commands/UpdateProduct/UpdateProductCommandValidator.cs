using System.Data;
using Ecommerce.Application.Features;
using FluentValidation;

namespace Ecommerce.Application.Feature;
public class UpdateProductCommandValidator: AbstractValidator<UpdateProductCommandRequest>
{
    public UpdateProductCommandValidator()
    {

        RuleFor(p => p.Id)
        .GreaterThan(0);

        RuleFor(p => p.Title)
         .NotEmpty();

        RuleFor(p => p.Description)
        .NotEmpty();

        RuleFor(p => p.BrandId) 
        .NotEmpty()
        .GreaterThan(0);

        RuleFor(p => p.Price)
        .NotEmpty().GreaterThan(0);

        RuleFor(p => p.Discount)
        .GreaterThanOrEqualTo(0);

        RuleFor(p => p.CategoryIds)
        .NotEmpty()
        .Must(categories => categories.Any());

        
    }
    
}
