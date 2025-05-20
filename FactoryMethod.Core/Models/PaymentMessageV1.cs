using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Core.Models
{
    public class PaymentMessageV1(string systemId)
    {
        public string SystemId => systemId;

        public string? SourceIdentifier { get; set; }

        public string? DestinationIdentifier { get; set; }

        public decimal? Amount { get; set; }

        public string? Currency { get; set; }
    }
}
