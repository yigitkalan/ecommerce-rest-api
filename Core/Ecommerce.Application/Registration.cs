using System.Reflection;
using Ecommerce.Application.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Application;
public static class Registration {
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddTransient<ExceptionMiddleware>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
    }
    public static void ConfigureExceptionHandlingMiddleware(this IApplicationBuilder app){
        app.UseMiddleware<ExceptionMiddleware>();
    }
}
