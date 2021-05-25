using System;
using System.Threading.Tasks;

namespace BookStore.API.Cache
{
    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeSpan);

        Task<string> GetCachedResponseAsync(string cacheKey);
    }
}