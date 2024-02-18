using Ecommerce.Application.Bases;
using Ecommerce.Application.Features;
using Ecommerce.Domain.Entities;

namespace Namespace;
public class ProductRules: BaseRules
{
    public Task ProductTitleMustBeUnique(IList<Product> products,  string requestTitle)
    {
        if(products.Any(p => p.Title == requestTitle))
        {
            throw new ProductTitleMustBeUniqueException();
        }
        return Task.CompletedTask;
    }
    
}
