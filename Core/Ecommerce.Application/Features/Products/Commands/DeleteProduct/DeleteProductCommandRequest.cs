using MediatR;

namespace Ecommerce.Application.Features;
public class DeleteProductCommandRequest: IRequest<Unit>
{
    public int Id { get; set; }
}
