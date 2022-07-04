using Crud.BackEnd.Infra.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Crud.BackEnd.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
