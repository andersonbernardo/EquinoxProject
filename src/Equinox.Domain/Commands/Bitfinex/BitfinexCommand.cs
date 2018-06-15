
using Equinox.Domain.Core.Commands;

namespace Equinox.Domain.Commands.Bitfinex
{
    public abstract class BitfinexCommand : Command
    {
        public string symbol { get; protected set; }
        public string amount { get; protected set; }
        public string price { get; protected set; }
        public string side { get; protected set; }
        public string type { get; protected set; }
        public string exchange { get; protected set; }
        public bool is_hidden { get; protected set; }
        public bool is_postonly { get; protected set; }
        public bool ocoorder { get; protected set; }
        public string buy_price_oco { get; protected set; }
        public string sell_price_oco { get; protected set; }
    }
}
