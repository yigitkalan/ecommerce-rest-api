using MediatR;

namespace Ecommerce.Application.Features;
public class GetAllProductsQueryRequest : IRequest<IList<GetAllProductsQueryResponse>>
{

}
