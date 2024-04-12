using Infrastructure.Services;
using System.Runtime.CompilerServices;

namespace Silicon.Configurations;

public static class ServicesConfiguration
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AccountService>();
    }
}
