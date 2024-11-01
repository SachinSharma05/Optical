using api.Abstraction.Services;

namespace api.Services
{
    public class Module : IModule
    {
        public void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
