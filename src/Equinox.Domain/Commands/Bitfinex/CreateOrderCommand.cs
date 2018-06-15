using Equinox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Equinox.Domain.Commands.Bitfinex
{
    public class CreateOrderCommand : BitfinexCommand
    {
        public CreateOrderCommand()
        {

        }

        public CreateOrderCommand(OrderBitfinex order)
        {
            symbol = order.symbol;
            side = order.side;
            is_hidden = order.is_hidden;
            is_postonly = order.is_postonly;
            ocoorder = order.ocoorder;
            buy_price_oco = order.buy_price_oco;
            amount = order.amount;
            price = order.price;
            sell_price_oco = order.sell_price_oco;                        
        }


        public override bool IsValid()
        {
            return true;
        }
    }
}
