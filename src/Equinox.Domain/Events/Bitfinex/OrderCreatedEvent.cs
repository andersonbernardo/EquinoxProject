using Equinox.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Equinox.Domain.Events.Bitfinex
{
    public class OrderCreatedEvent : Event
    {        
        public OrderCreatedEvent(int id, string symbol, string exchange, decimal price)
        {
            Id = id;
            Symbol = symbol;
            Exchange = exchange;
            Price = price;
        }

        public int Id { get; private set; }
        public string Symbol { get; private set; }
        public string Exchange { get; private set; }
        public decimal Price { get; set; }
    }
}
