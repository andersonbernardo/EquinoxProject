using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Equinox.Domain.Commands.Bitfinex;
using Equinox.Domain.Core.Bus;
using Equinox.Domain.Core.Notifications;
using Equinox.Domain.Events.Bitfinex;
using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using MediatR;

namespace Equinox.Domain.CommandHandlers.Bitfinex
{
    public class OrderCommandHandler : CommandHandler
                                    , IAsyncNotificationHandler<CreateOrderCommand>,
                                      IAsyncNotificationHandler<CancelOrderCommand>
    {       

        private readonly IBitfinexRepository _bitfinexRepository;
        private readonly IMediatorHandler Bus;

        public OrderCommandHandler(IBitfinexRepository bitfinexRepository, IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _bitfinexRepository = bitfinexRepository;
             Bus = bus;
        }

        public async Task Handle(CreateOrderCommand message)
        {
            if(!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var order = new OrderBitfinex  {
                amount = message.amount,
                buy_price_oco = message.buy_price_oco,
                is_hidden = message.is_hidden,
                is_postonly = message.is_postonly,
                ocoorder = message.ocoorder,
                price = message.price,
                sell_price_oco = message.sell_price_oco,
                side = message.side,
                symbol = message.symbol,
                type = message.type
            };

            var result = await _bitfinexRepository.CreateOrder(order).ConfigureAwait(false);

            if (result.Id > 0)
                await Bus.RaiseEvent(new OrderCreatedEvent(result.Id, result.Symbol, result.Exchange, result.Price));
            
        }

        public async Task Handle(CancelOrderCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var order = new CancelOrderBitfinex
            {
                order_id = message.order_id
            };

            var result = await _bitfinexRepository.CancelOrder(order).ConfigureAwait(false);

            //if (result.Id > 0)
                //await Bus.RaiseEvent(new OrderCanceledEvent(long.Parse(result.Id.ToString())));
            
        }
    }
}
