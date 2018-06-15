using System;
using System.Collections.Generic;
using System.Text;

namespace Equinox.Domain.Models
{
    public class CancelOrderBitfinex : BaseBitfinex
    {
        public long order_id { get; set; }
    }
}
