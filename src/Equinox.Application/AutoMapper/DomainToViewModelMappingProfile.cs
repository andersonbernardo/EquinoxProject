using AutoMapper;
using Equinox.Application.ViewModels;
using Equinox.Domain.Commands.Bitfinex;
using Equinox.Domain.Models;

namespace Equinox.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<OrderBitfinex, OrderBitfinexViewModel>();

            CreateMap<CreateOrderCommand, OrderBitfinexViewModel>();
            CreateMap<CancelOrderCommand, CancelOrderBitfinexViewModel>();
        }
    }
}
