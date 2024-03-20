using Ecommerce.Domain.Entities;
using MediatR;
using Namespace;

namespace Ecommerce.Application.Features;

// we need the response of some kind to be able to enter the validation behavior pipeline, so we use Unit
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest,Unit>
{
    private IUnitOfWork unitOfWork;
    private ProductRules productRules;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork, ProductRules productRules)
    {
        this.unitOfWork = unitOfWork;
        this.productRules = productRules;

    }
    public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();
        await productRules.ProductTitleMustBeUnique(products, request.Title);

        Product product = new(request.Title, request.Description, request.BrandId, request.Price, request.Discount);

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
        var categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync(predicate: c => !c.IsDeleted && request.CategoryIds.Contains(c.Id) , enableTracking: true);

        foreach (var category in categories)
        {
            product.Categories.Add(category);
        }


        var result = await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}
