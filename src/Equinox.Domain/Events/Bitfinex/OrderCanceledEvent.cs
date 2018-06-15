using Equinox.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Equinox.Domain.Events.Bitfinex
{
    public class OrderCanceledEvent : Event
    {
        public OrderCanceledEvent(int dd)
        {
            Id = Id;
        }

        public long Id { get; set; }
    }
}
