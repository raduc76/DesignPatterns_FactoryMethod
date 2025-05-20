using FactoryMethod.Core.Models;
using FactoryMethod.Core.Models.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FactoryMethod.Core.Processors
{
    public class MessageProcessorV1 : MessageProcessor, IMessageProcessor
    {
        protected override void AddDetailsToModel(string messageBody, Payment payment)
        {
            //call external endpoint for V1 identifiers for getting source and destination name
            var sourceName = "Ion Ionescu";
            var destinationName = "Emag SRL";

            payment.SourceName = sourceName;
            payment.DestinationName = destinationName;

            Console.WriteLine("MessageProcessorV1.AddDetailsToModel executed");
        }

        protected override Payment MapMessageToModel(string messageBody)
        {
            PaymentMessageV1 message = JsonSerializer.Deserialize<PaymentMessageV1>(messageBody)!;

            var payment = new Payment(message.SystemId);
            payment.SourceId = message.SourceIdentifier;
            payment.DestinationId = message.DestinationIdentifier;
            payment.Amount = message.Amount;
            payment.Currency = message.Currency;

            Console.WriteLine("MessageProcessorV1.MapMessageToModel executed");

            return payment;
        }
    }
}
