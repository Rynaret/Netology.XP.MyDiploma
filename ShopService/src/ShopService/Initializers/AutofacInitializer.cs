using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using ShopService.Conventions;
using ShopService.Initializers.AutofacConfigs;

namespace ShopService.Initializers
{
    /// <summary>
    /// Инициализатор зависимостей в Autofac-е
    /// </summary>
    public class AutofacInitializer
    {
        public static IServiceProvider Initialize(IServiceCollection services, IContainer container)
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterDependencies();

            builder.Populate(services);
            container = builder.Build();

            // запускаем все инициализаторы
            var initializers = container.Resolve<IEnumerable<IInitializable>>();

            foreach (var initializer in initializers.OrderBy(x => x.Order))
            {
                initializer.Initialize();
            }

            return new AutofacServiceProvider(container);
        }
    }
}