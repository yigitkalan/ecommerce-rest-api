using Ecommerce.Application.Bases;

namespace Ecommerce.Application.Features;
public class ProductTitleMustBeUniqueException: BaseExceptions
{
    public ProductTitleMustBeUniqueException(): base("Product title is already in use") { }
}