using FactoryMethod.Core.Models.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Core.Processors
{
    public abstract class MessageProcessor : IMessageProcessor
    {
        public void Process(string messageBody)
        {
            var payment = MapMessageToModel(messageBody);

            AddDetailsToModel(messageBody, payment);

            PersistModel(payment);
        }

        protected void PersistModel(Payment payment)
        {
            //persist to database here

            Console.WriteLine("MessageProcessor.PersistModel executed");
        }

        protected abstract Payment MapMessageToModel(string messageBody);

        protected abstract void AddDetailsToModel(string messageBody, Payment payment);
    }
}
