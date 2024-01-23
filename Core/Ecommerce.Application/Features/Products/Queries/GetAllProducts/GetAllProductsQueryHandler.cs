using System.Diagnostics;
using Ecommerce.Domain;
using MediatR;

namespace Ecommerce.Application;
public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
{
    private IUnitOfWork unityOfWork;
    public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
    {
        unityOfWork = unitOfWork;
    }


    public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var products = await unityOfWork.GetReadRepository<Product>().GetAllAsync();
        List<GetAllProductsQueryResponse> responses = products.Select(p => new GetAllProductsQueryResponse{
                Description = p.Description,
                Discount = p.Discount,
                Price = p.Price - (p.Price * p.Discount / 100),
                Title = p.Title
        }).ToList();
        return responses;
    }
}
