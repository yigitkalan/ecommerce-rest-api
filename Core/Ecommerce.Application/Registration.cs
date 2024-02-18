using System.Reflection;
using Ecommerce.Application.Bases;
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

        services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));
    }

    public static void ConfigureExceptionHandlingMiddleware(this IApplicationBuilder app){
        app.UseMiddleware<ExceptionMiddleware>();
    }

    private static void AddRulesFromAssemblyContaining(
        this IServiceCollection services
        , Assembly assembly
        , Type type)
    {
        var types = 
            assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(type));

        types.ToList().ForEach(t => services.AddTransient(t));
    }
}
