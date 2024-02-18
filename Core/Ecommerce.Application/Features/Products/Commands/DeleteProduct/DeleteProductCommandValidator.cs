using FluentValidation;

namespace Ecommerce.Application.Features;
public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommandRequest>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(p => p.Id)
        .GreaterThan(0);

    }
}
