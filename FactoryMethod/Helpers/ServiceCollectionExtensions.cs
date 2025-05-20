using FactoryMethod.Core.Factories;
using FactoryMethod.Core.Processors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Helpers
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMessageProcessorFactory(this IServiceCollection services)
        {
            services.AddSingleton<IMessageProcessorFactory, MessageProcessorFactory>();
        }

        public static void AddMessageProcessorFactoryWithDI(this IServiceCollection services)
        {
            services.AddSingleton<IMessageProcessorFactory, MessageProcessorFactoryDI>()
                            .AddScoped<MessageProcessorV1>()
                            .AddScoped<IMessageProcessor, MessageProcessorV1>(s => s.GetService<MessageProcessorV1>()!)
                            .AddScoped<MessageProcessorV2>()
                            .AddScoped<IMessageProcessor, MessageProcessorV2>(s => s.GetService<MessageProcessorV2>()!);
        }
    }
}
