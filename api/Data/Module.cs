using api.Abstraction.Data;
using api.Data.Auth;

namespace api.Data
{
    public class Module : IModule
    {
        public void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
        }
    }
}
