using FactoryMethod.Core.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Core.Factories
{
    public interface IMessageProcessorFactory
    {
        IMessageProcessor CreateMessageProcessor(string messageType);
    }
}
