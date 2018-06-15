using System;
using Equinox.Domain.Core.Models;
namespace Equinox.Domain.Models
{
    public class OrderBitfinex : BaseBitfinex
    {
        public string symbol { get; set; }
        public string amount { get; set; }
        public string price { get; set; }
        public string side { get; set; }
        public string type { get; set; }
        public string exchange { get; set; }
        public bool is_hidden { get; set; }
        public bool is_postonly { get; set; }
        public bool ocoorder { get; set; }
        public string buy_price_oco { get; set; }
        public string sell_price_oco { get; set; }        

    }
}
