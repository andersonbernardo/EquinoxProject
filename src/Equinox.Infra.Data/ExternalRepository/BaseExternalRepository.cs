using Equinox.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Equinox.Infra.CrossCutting.Tools;

namespace Equinox.Infra.Data.ExternalRepository
{
    public class BaseExternalRepository : IBaseExternalRepository
    {
        private string _host;


        public BaseExternalRepository(string host)
        {
            _host = host;
        }

        public Task<TEntity> GetAsync<TEntity>(string url)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Post com parametros enviado pela url
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TParam"></typeparam>
        /// <param name="url"></param>
        /// <param name="parametros"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public async Task<TEntity> PostAsUrlEncondeParamsAsync<TEntity>(string url, Dictionary<string, string> headers)
        {
            using (var _client = CreateClientWithHearders(url, _host, headers))
            {
                var response = await _client.PostAsync(url, null).ConfigureAwait(false);
                return await TratarRequisicao<TEntity>(response);

            }
        }

        public async Task<TEntity> GetAsUrlEncondeParamsAsync<TEntity>(string url, Dictionary<string, string> headers)
        {

            using (var _client = CreateClientWithHearders(url, _host, headers))
            {
                var response = await _client.GetAsync(url).ConfigureAwait(false);
                return await TratarRequisicao<TEntity>(response);

            }
        }

        /// <summary>
        /// Post com os parametros em formato Json
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TParam"></typeparam>
        /// <param name="url"></param>
        /// <param name="parametros"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public async Task<TEntity> PostAsJsonAsync<TEntity, TParam>(string url, TParam parametros, Dictionary<string, string> headers)
        {
            using (var _client = CreateClientWithHearders(url, _host, headers))
            {
                string stringData = Json.Serialize(parametros);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                var req = await _client.PostAsync(url, contentData).ConfigureAwait(false);
                return await TratarRequisicao<TEntity>(req);
            }
        }

        public async Task<TEntity> PostAsJsonAsync<TEntity, TParam>(string url, TParam parametros)
        {
            using (var _client = CreateClientSemAuthentication(url, _host))
            {
                string stringData = JsonConvert.SerializeObject(parametros);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                var req = await _client.PostAsync(url, contentData).ConfigureAwait(false);
                return await TratarRequisicao<TEntity>(req);
            }
        }

        private static async Task<TRetorno> TratarRequisicao<TRetorno>(HttpResponseMessage requisicao)
        {
            var conteudo = await requisicao.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TRetorno>(conteudo);
        }

        #region CLIENTS
        private static HttpClient CreateClientWithHearders(string url, string host, Dictionary<string, string> headers)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(host);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));         

            foreach (var value in headers)
            {
                client.DefaultRequestHeaders.Add(value.Key, value.Value);
            }

            return client;
        }

        private static HttpClient CreateClientWithAuthentication(string url, string host, string authHeader, string type)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(host);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(type, authHeader);

            return client;
        }

        private static HttpClient CreateClientSemAuthentication(string url, string host)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(host);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
        #endregion

    }
}
