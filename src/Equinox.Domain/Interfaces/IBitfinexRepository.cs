﻿using Equinox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Interfaces
{
    public interface IBitfinexRepository
    {
        Task<OrderBitfinexResult> CreateOrder(OrderBitfinex order);
        Task<CancelOrderBitfinex> CancelOrder(CancelOrderBitfinex order);
        Task<IEnumerable<OrderBitfinex>> GetOrders();
    }
}
