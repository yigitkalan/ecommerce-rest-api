using System.Reflection;
using Ecommerce.Application;
using Ecommerce.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Mapper
;
public static class Registration
{
    public static void AddCustomMapper(this IServiceCollection services)
    {
        services.AddSingleton<IMapper, Mapper>();
    }
    
}
