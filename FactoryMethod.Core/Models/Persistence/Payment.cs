using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Core.Models.Persistence
{
    public class Payment(string systemId)
    {
        public string SystemId = systemId;

        public string? SourceId { get; set; }

        public string? SourceName { get; set; }

        public string? DestinationId { get; set; }

        public string? DestinationName { get; set; }

        public decimal? Amount { get; set; }

        public string? Currency { get; set; }
    }
}
