using Equinox.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Application.Interfaces
{
    public interface IBitfinexAppService : IDisposable
    {
        void CreateOrder(OrderBitfinexViewModel orderBitfinexViewModel);

        void CancelOrder(CancelOrderBitfinexViewModel orderBitfinexViewModel);

        Task<IEnumerable<OrderBitfinexViewModel>> GetOrders();
    }
}
