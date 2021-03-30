using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
