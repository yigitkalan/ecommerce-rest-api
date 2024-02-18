using Ecommerce.Application.Features;
using Ecommerce.Application.Interfaces.Repositories;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.Feature;
public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, Unit>
{
    private IUnitOfWork unitOfWork;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
        
    }
    public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        Product product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
        product.IsDeleted = true;

        await unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
        await unitOfWork.SaveAsync();

        return Unit.Value;
    }
}
