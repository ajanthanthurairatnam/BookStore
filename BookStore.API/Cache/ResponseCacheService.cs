using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace BookStore.API.Cache
{
    public class ResponseCacheService : IResponseCacheService
    {
        private readonly IDistributedCache distributedCache;
        public ResponseCacheService(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }

        public async Task<string> GetCachedResponseAsync(string cacheKey)
        {
            var cachedResponse = await distributedCache.GetStringAsync(cacheKey);
            return string.IsNullOrEmpty(cachedResponse) ? null : cachedResponse;
        }

        public async Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeSpanLive)
        {
            if(response==null)
            {
                return;
            }
            var serializedResponse = JsonConvert.SerializeObject(response);

            await distributedCache.SetStringAsync(cacheKey, serializedResponse, new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = timeSpanLive
            });

        }
    }
}