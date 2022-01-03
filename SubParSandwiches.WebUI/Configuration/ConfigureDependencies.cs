using Microsoft.Extensions.DependencyInjection;
using SubParSandwiches.Services.Implementations;
using SubParSandwiches.Services.Interfaces;
using SubParSandwiches.WebUI.Helpers;
using SubParSandwiches.WebUI.Interfaces;

namespace SubParSandwiches.WebUI.Configuration
{
    public class ConfigureDependencies
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IUserAccessor, UserAccessor>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<ICatalogService, CatalogService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IFileHelper, FileHelper>();
        }
    }
}
