using System;
using System.Collections.Generic;
using System.Text;
using Equinox.Domain.Commands.Bitfinex;
using Equinox.Domain.Core.Bus;
using Equinox.Domain.Core.Notifications;
using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using MediatR;

namespace Equinox.Domain.CommandHandlers.Bitfinex
{
    public class OrderCommandHandler : CommandHandler
    {
        private readonly IBitfinexRepository _bitfinexRepository;
        private readonly IMediatorHandler Bus;

        public OrderCommandHandler(IBitfinexRepository bitfinexRepository, IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _bitfinexRepository = bitfinexRepository;
            Bus = bus;
        }

        public void Handle(CreateOrderCommand message)
        {
            if (message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var order = new OrderBitfinex()
            {
                Amount = "100"

            };

            var result = _bitfinexRepository.CreateOrder(order);
        }

    }
}
