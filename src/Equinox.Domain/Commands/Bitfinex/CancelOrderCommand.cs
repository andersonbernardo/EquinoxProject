using Equinox.Domain.Core.Commands;
using Equinox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Equinox.Domain.Commands.Bitfinex
{
    public class CancelOrderCommand : BitfinexCommand
    {
        public CancelOrderCommand()
        {

        }

        public CancelOrderCommand(CancelOrderBitfinex order)
        {
            order_id = order.order_id;
        }

        public long order_id { get; set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}