using Equinox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Interfaces
{
    public interface IBitfinexRepository : IBaseExternalRepository
    {
        Task<OrderBitfinex> CreateOrder(OrderBitfinex order);
    }
}
