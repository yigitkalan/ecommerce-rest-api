using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Application.Features;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductController : ControllerBase
{
    private IMediator Mediator { get; }
    public ProductController(IMediator mediator)
    {
        Mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var response = await Mediator.Send(new GetAllProductsQueryRequest());

        return Ok(response);

    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommandRequest request)
    {
        await Mediator.Send(request);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest request)
    {
        await Mediator.Send(request);
        return Ok();
    }

    [HttpDelete]

    public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommandRequest request)
    {
        await Mediator.Send(request);
        return Ok();
    }

    
}
