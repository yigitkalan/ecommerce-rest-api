using MediatR;

namespace Ecommerce.Application;
public class GetAllProductsQueryRequest : IRequest<IList<GetAllProductsQueryResponse>>
{

}
