using System.Reflection;
using Ecommerce.Application.Behaviors;
using Ecommerce.Application.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Application;
public static class Registration {
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddTransient<ExceptionMiddleware>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddValidatorsFromAssembly(assembly);
        ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("en");

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
    }

    public static void ConfigureExceptionHandlingMiddleware(this IApplicationBuilder app){
        app.UseMiddleware<ExceptionMiddleware>();
    }
}
