//using BookADinner.Application.Services.Authentication;
using BookADinner.Application.Common.Interface.Authentication;
using BookADinner.Application.Common.Interface.Persistence;
using BookADinner.Application.Common.Interfaces.Services;
using BookADinner.Infrastructure.Authentication;
using BookADinner.Infrastructure.Persistence;
using BookADinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookADinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
         ConfigurationManager configuration)
    {    
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));    
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();
        
         return services;
    }
}