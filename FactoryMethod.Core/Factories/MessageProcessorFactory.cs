using FactoryMethod.Core.Models;
using FactoryMethod.Core.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Core.Factories
{
    public class MessageProcessorFactory : IMessageProcessorFactory
    {
        public IMessageProcessor CreateMessageProcessor(string messageType)
        {
            IMessageProcessor result;

            result = messageType switch
            {
                Constants.V1_MESSAGE_TYPE => new MessageProcessorV1(),
                Constants.V2_MESSAGE_TYPE => new MessageProcessorV2(),
                _ => throw new NotImplementedException()
            };

            Console.WriteLine($"Message processor factory called for type {messageType} with processor of type {result.GetType().Name} created");
            return result;
        }
    }
}
