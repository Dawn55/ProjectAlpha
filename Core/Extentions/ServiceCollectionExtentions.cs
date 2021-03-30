using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extentions
{
   public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceDescriptors,ICoreModule[] coreModules)
        {
            foreach (var item in coreModules)
            {
                item.Load(serviceDescriptors);
            }
            return ServiceTool.Create(serviceDescriptors);
        }
    }
}
