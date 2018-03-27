using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Infra.Data.ExternalRepository
{
    public class BitfinexRepository : BaseExternalRepository, IBitfinexRepository
    {
        public BitfinexRepository(string host) : base(host)
        {

        }

        public Task<IEnumerable<OrderBitfinex>> GetOrders()
        {
            throw new NotImplementedException("GetOrer");
        }

        public Task<OrderBitfinex> CreateOrder(OrderBitfinex order)
        {
            throw new NotImplementedException("Create order");
        }


        //private Dictionary<string, string> GetAuth()
        //{
        //    return new Dictionary<string, string>
        //    {
        //        { "key", _keyApi },
        //        { "nonce", _nonce },
        //        { "signature", CriptographyHelper.CreateTokenHMACSHA256(_message,_secretKey) }
        //    };
        //}
    }
}
