using System.Diagnostics;
using Ecommerce.Domain.DTOs;
using Ecommerce.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Application.Features;
public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
{
    private readonly IUnitOfWork unityOfWork;
    private readonly IMapper mapper;
    public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        unityOfWork = unitOfWork;
        this.mapper = mapper;
    }


    public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var products = await unityOfWork.GetReadRepository<Product>().GetAllAsync(include: q => q.Include(x => x.Brand));
        //by doing this we are adding mapping configuration for brand and branddto via the Config method
        mapper.Config<BrandDto, Brand>();
        var map = mapper.Map<GetAllProductsQueryResponse, Product>(products);
        foreach (var item in map)
        item.Price -= item.Price * item.Discount / 100;
        return map;
    }
}
