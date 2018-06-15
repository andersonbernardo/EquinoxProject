using AutoMapper;
using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Equinox.Domain.Commands.Bitfinex;
using Equinox.Domain.Core.Bus;
using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Application.Services
{
    public class BitfinexAppService :  IBitfinexAppService
    {
        private readonly IMapper _mapper;        
        private readonly IMediatorHandler _Bus;
        private readonly IBitfinexRepository _bitfinexRepository;

        public BitfinexAppService(IMapper mapper, IMediatorHandler Bus, IBitfinexRepository bitfinexRepository)
        {
            _mapper = mapper;
            _Bus = Bus;
            _bitfinexRepository = bitfinexRepository;
        }

        public void CancelOrder(CancelOrderBitfinexViewModel order)
        {
            var registerCommand = _mapper.Map<CancelOrderCommand>(order);
            _Bus.SendCommand(registerCommand);
        }

        public void CreateOrder(OrderBitfinexViewModel orderBitfinexViewModel)
        {
            var registerCommand = _mapper.Map<CreateOrderCommand>(orderBitfinexViewModel);
            _Bus.SendCommand(registerCommand);
        }

        public async Task<IEnumerable<OrderBitfinexViewModel>> GetOrders()
        {
            var result = await _bitfinexRepository.GetOrders().ConfigureAwait(false);

            return _mapper.Map<IEnumerable<OrderBitfinexViewModel>>(result);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
