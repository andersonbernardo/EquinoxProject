
using Equinox.Domain.Core.Commands;

namespace Equinox.Domain.Commands.Bitfinex
{
    public abstract class BitfinexCommand : Command
    {
        public string Symbol { get; protected set; }
        public string Amount { get; protected set; }
        public string Price { get; protected set; }
        public string Side { get; protected set; }
        public string Type { get; protected set; }
        public bool Is_hidden { get; protected set; }
        public bool Is_postonly { get; protected set; }
        public bool Ocoorder { get; protected set; }
        public int Buy_price_oco { get; protected set; }
        public int Sell_price_oco { get; protected set; }
    }
}
