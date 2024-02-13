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

        await unitOfWork.GetWriteRepository<Product>().AddAsync(product);
        if(await unitOfWork.SaveAsync() == 0)
        {
            throw new Exception("Failed to create product");
        }

        // When this parameter is set to false, EF assumes you don't intend to modify the retrieved entities.
        // As a result, it creates detached entities, meaning they are not tracked in the EF context and have 
        // no relationship with the database. When you attempt to add a new product object that is based on 
        // one of these detached entities, EF cannot identify or associate it with any existing database entity.
        // so it will try to insert a new record into the database, which will result in a primary key violation.
        var categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync(predicate: c => request.CategoryIds.Contains(c.Id), enableTracking: true);

        foreach (var category in categories)
        {
            product.Categories.Add(category);
        }


        var result = await unitOfWork.SaveAsync();
    }
}
