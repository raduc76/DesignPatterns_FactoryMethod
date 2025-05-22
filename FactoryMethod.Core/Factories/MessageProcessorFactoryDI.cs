using FactoryMethod.Core.Models;
using FactoryMethod.Core.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Core.Factories
{
    public class MessageProcessorFactoryDI : IMessageProcessorFactory
    {
        private readonly IServiceProvider serviceProvider;

        public MessageProcessorFactoryDI(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IMessageProcessor CreateMessageProcessor(string messageType)
        {
            IMessageProcessor result;

            result = messageType switch
            {
                Constants.V1_MESSAGE_TYPE => (IMessageProcessor)serviceProvider.GetService(typeof(MessageProcessorV1))!,
                Constants.V2_MESSAGE_TYPE => (IMessageProcessor)serviceProvider.GetService(typeof(MessageProcessorV2))!,
                _ => throw new NotImplementedException()
            };

            Console.WriteLine($"Message processor factory with DI called for type {messageType} with processor of type {result.GetType().Name} created");
            return result;
        }
    }
}
