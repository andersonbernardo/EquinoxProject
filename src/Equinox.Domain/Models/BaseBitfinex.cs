using System;
using System.Collections.Generic;
using System.Text;

namespace Equinox.Domain.Models
{
    public abstract class BaseBitfinex
    {
        public string request { get; set; }
        public string nonce { get; set; }
    }
}
