using Ecommerce.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Application.Features;
public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
{
    private IUnitOfWork unitOfWork;
    private IMapper mapper;

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;

    }
    public async Task Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id, enableTracking: true, include : x => x.Include(p => p.Categories));
        foreach (var productCategory in product.Categories.ToList())
        {
            product.Categories.Remove(productCategory);
        }

        Product mapped = mapper.Map<Product, UpdateProductCommandRequest>(request);

        var categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync(predicate: c => !c.IsDeleted && request.CategoryIds.Contains(c.Id), enableTracking: true);
        foreach (var category in categories)
        {
            product.Categories.Add(category);
        }

        product.Title = mapped.Title;
        product.Description = mapped.Description;
        product.Price = mapped.Price;
        product.BrandId = mapped.BrandId;
        product.Discount = mapped.Discount;


        await unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
        await unitOfWork.SaveAsync();

    }
}
