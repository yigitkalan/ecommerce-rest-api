﻿using Ecommerce.Application;
using Ecommerce.Application.Interfaces.Repositories;
using Ecommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Persistance;

public static class Registration
{
    public static void AddPersistance(this IServiceCollection services, IConfiguration configuration){
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("LiteConnection"));
        });

        //since repositores are generic we can use type of to register them,
        // so when we encounter an an instance of IReadRepository<T> we know what to inject
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

        services.AddIdentityCore<User>( opt =>{
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequiredLength = 8;
            opt.Password.RequireLowercase = false;
            opt.Password.RequireUppercase = false;
            opt.Password.RequireDigit = false;
            opt.SignIn.RequireConfirmedEmail = false;

        }).AddRoles<Role>().AddEntityFrameworkStores<AppDbContext>();
    }


}
