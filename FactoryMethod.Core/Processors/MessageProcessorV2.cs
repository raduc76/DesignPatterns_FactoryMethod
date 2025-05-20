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
    public class MessageProcessorV2 : MessageProcessor, IMessageProcessor
    {
        protected override void AddDetailsToModel(string messageBody, Payment payment)
        {
            //call external endpoint for V2 identifiers for getting source and destination name
            var sourceName = "Emil Popescu";
            var destinationName = "PC Garage SRL";

            payment.SourceName = sourceName;
            payment.DestinationName = destinationName;

            Console.WriteLine("MessageProcessorV2.AddDetailsToModel executed");
        }

        protected override Payment MapMessageToModel(string messageBody)
        {
            PaymentMessageV2 message = JsonSerializer.Deserialize<PaymentMessageV2>(messageBody)!;

            var payment = new Payment(message.SystemId);
            payment.SourceId = message.Party!.Id;
            payment.DestinationId = message.CounterParty!.Id;
            payment.Amount = message.Value;
            payment.Currency = message.Currency;

            Console.WriteLine("MessageProcessorV2.MapMessageToModel executed"); 

            return payment;
        }
    }
}
