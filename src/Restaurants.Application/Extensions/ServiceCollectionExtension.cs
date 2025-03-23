using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Users;

namespace Restaurants.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssempbly = typeof(ServiceCollectionExtensions).Assembly;

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssempbly));

        services.AddAutoMapper(applicationAssempbly);

        services.AddValidatorsFromAssembly(applicationAssempbly)
            .AddFluentValidationAutoValidation(); // replace endopoint validations

        services.AddScoped<IUserContext, UserContext>();

        services.AddHttpContextAccessor(); //dobbiamo richiamarlo perchè lo iniettiamo nel userContext 
        
    }
}
