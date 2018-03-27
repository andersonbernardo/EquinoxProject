using System;
using Equinox.Domain.Core.Models;
namespace Equinox.Domain.Models
{
    public class OrderBitfinex
    {        
        public string Symbol { get; set; }
        public string Amount { get; set; }
        public string Price { get; set; }
        public string Side { get; set; }
        public string Type { get; set; }
        public bool Is_hidden { get; set; }
        public bool Is_postonly { get; set; }
        public bool Ocoorder { get; set; }
        public int Buy_price_oco { get; set; }
        public int Sell_price_oco { get; set; }
    }
}
