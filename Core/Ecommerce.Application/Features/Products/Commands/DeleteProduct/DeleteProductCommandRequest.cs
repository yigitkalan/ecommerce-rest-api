using MediatR;

namespace Ecommerce.Application.Features;
public class DeleteProductCommandRequest: IRequest
{
    public int Id { get; set; }
}
