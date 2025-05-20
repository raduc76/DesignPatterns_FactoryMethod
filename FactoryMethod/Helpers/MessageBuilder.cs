using FactoryMethod.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FactoryMethod.Helpers
{
    public class MessageBuilder
    {
        public static string BuildV1Message()
        {
            var message = new PaymentMessageV1(Guid.NewGuid().ToString());
            message.SourceIdentifier = Guid.NewGuid().ToString();
            message.DestinationIdentifier = Guid.NewGuid().ToString();
            message.Currency = "EUR";
            message.Amount = 100;

            return JsonSerializer.Serialize(message);
        }

        public static string BuildV2Message()
        {
            var message = new PaymentMessageV2(Guid.NewGuid().ToString());
            message.Party = new Party { Id = Guid.NewGuid().ToString() };
            message.CounterParty = new CounterParty { Id = Guid.NewGuid().ToString() };
            message.Currency = "RON";
            message.Value = 1000;

            return JsonSerializer.Serialize(message);
        }
    }
}
