using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Features;
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
{
    private IUnitOfWork unitOfWork;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;

    }
    public async Task Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        Product product = new Product(request.Title, request.Description, request.BrandId, request.Price, request.Discount);

        var categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync(predicate: c => request.CategoryIds.Contains(c.Id));

        foreach (var category in categories)
        {
            product.Categories.Add(category);
        }

        await unitOfWork.GetWriteRepository<Product>().AddAsync(product);

        var result = await unitOfWork.SaveAsync();
    }
}
