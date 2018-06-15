using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Linq;
using Equinox.Infra.CrossCutting.Tools;
using Equinox.Infra.CrossCutting.Cryptography;

namespace Equinox.Infra.Data.ExternalRepository
{
    public class Model
    {
        public string nonce { get; set; }
        public string request { get; set; }
    }

    public class BitfinexRepository : BaseExternalRepository, IBitfinexRepository
    {
        private const string pathV1 = "/v1/";
        private const string pathV2 = "/v2/auth/r/";        

        public BitfinexRepository() : base("https://api.bitfinex.com")
        {

        }

        public async Task<IEnumerable<OrderBitfinex>> GetOrders()
        {
            var fullUrl = $"{pathV1}orders";

            var model = new Model { request = fullUrl, nonce = new DateTime().UnixTimestamp().ToString() };

            return await PostAsJsonAsync<IEnumerable<OrderBitfinex>, Model>(fullUrl, model, GetAuth(model));
        }

        public async Task<OrderBitfinexResult> CreateOrder(OrderBitfinex order)
        {
            var fullUrl = $"{pathV1}order/new";

            order.request = fullUrl;
            order.nonce = new DateTime().UnixTimestamp().ToString();            

            return await PostAsJsonAsync<OrderBitfinexResult, OrderBitfinex>(fullUrl, order, GetAuth(order)).ConfigureAwait(false);
        }


        public async Task<CancelOrderBitfinex> CancelOrder(CancelOrderBitfinex order)
        {
            var fullUrl = $"{pathV1}order/cancel";
            order.request = fullUrl;
            order.nonce = new DateTime().UnixTimestamp().ToString();

            

            return await PostAsJsonAsync<CancelOrderBitfinex, CancelOrderBitfinex>(fullUrl, order, GetAuth(order)).ConfigureAwait(false);
        }

        private Dictionary<string, string> GetAuth(object model)
        {

            // key tudo liberado a9LaadvTMf7V58kj2mdIcz9yYUiXoft6dCqSoYBNxOw
            // secret FClLgz8REZWBAm29iZDxKsg8P62XCCpRsW92aNChrvb

            var payload = Base64.Encode(Json.Serialize(model));

            return new Dictionary<string, string>
            {
                { "X-BFX-SIGNATURE", Hmac384.Create(payload, "FClLgz8REZWBAm29iZDxKsg8P62XCCpRsW92aNChrvb") },
                { "X-BFX-PAYLOAD", payload },
                { "X-BFX-APIKEY", "a9LaadvTMf7V58kj2mdIcz9yYUiXoft6dCqSoYBNxOw" }
           };
        }
        
    }
}
