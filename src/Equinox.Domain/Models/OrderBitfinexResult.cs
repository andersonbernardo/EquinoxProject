using System;
using System.Collections.Generic;
using System.Text;

namespace Equinox.Domain.Models
{
    public class OrderBitfinexResult
    {
       public int Id { get; set; }
       public string Symbol { get; set; }
       public string Exchange { get; set; } 
       public decimal Price { get; set; }  
    }
}
