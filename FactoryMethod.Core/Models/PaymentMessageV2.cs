using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Core.Models
{
    public class PaymentMessageV2(string systemId)
    {
        public string SystemId => systemId;

        public Party? Party { get; set; }

        public CounterParty? CounterParty { get; set; }

        public decimal? Value { get; set; }

        public string? Currency { get; set; }
    }
}
