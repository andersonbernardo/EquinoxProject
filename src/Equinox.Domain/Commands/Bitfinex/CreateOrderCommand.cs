using Equinox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Equinox.Domain.Commands.Bitfinex
{
    public class CreateOrderCommand : BitfinexCommand
    {

        public CreateOrderCommand(OrderBitfinex order)
        {
            Symbol = order.Symbol;
            Side = order.Side;
            Is_hidden = order.Is_hidden;
            Is_postonly = order.Is_postonly;
            Ocoorder = order.Ocoorder;
            Buy_price_oco = order.Buy_price_oco;
            Amount = order.Amount;
            Price = order.Price;
            Sell_price_oco = order.Sell_price_oco;            
            
        }


        public override bool IsValid()
        {
            return true;
        }
    }
}
