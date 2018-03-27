using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Equinox.Domain.Interfaces
{
    public interface IBaseExternalRepository
    {
        Task<TEntity> GetAsync<TEntity>(string url);

        Task<TEntity> GetAsUrlEncondeParamsAsync<TEntity>(string url, Dictionary<string, string> headers);

        Task<TEntity> PostAsJsonAsync<TEntity, TParam>(string url, TParam parametros);

        Task<TEntity> PostAsJsonAsync<TEntity, TParam>(string url, TParam parametros, Dictionary<string, string> headers);

        Task<TEntity> PostAsUrlEncondeParamsAsync<TEntity>(string url, Dictionary<string, string> headers);
    }
}
