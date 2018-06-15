using Equinox.Domain.Events.Bitfinex;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Equinox.Domain.EventHandlers.Bitfinex
{
    public class OrderEventHandler : INotificationHandler<OrderCreatedEvent>, INotificationHandler<OrderCanceledEvent>
    {
        public void Handle(OrderCreatedEvent notification)
        {
            
        }

        public void Handle(OrderCanceledEvent notification)
        {

        }
    }
}
