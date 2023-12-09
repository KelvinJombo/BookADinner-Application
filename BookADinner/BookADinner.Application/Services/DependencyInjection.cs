using BookADinner.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace BookADinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
         services.AddScoped<IAuthenticationService, AuthenticationServices>();

         return services;
    }
}