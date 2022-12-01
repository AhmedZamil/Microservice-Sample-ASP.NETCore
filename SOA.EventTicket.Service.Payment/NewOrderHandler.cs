using Messages;
using Rebus.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SOA.EventTicket.Service.Payment
{
    internal class NewOrderHandler : IHandleMessages<PaymentRequestMessage>
    {
        public Task Handle(PaymentRequestMessage message)
        {
            Console.WriteLine($"Payment request received for basket id {message.BasketId}.");
            return Task.CompletedTask;
        }
    }
}
