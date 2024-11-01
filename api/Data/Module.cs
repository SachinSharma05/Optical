using api.Abstraction.Data;
using api.Data.Auth;
using api.Data.Catgories;

namespace api.Data
{
    public class Module : IModule
    {
        public void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
