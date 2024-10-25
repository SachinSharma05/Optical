namespace api
{
    public static class DependencyInjectionManager
    {
        public static void Bootstrap(IServiceCollection services, List<IModule> modules)
        {
            foreach (var module in modules)
            {
                module.RegisterServices(services);
            }
        }
    }
}
