using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace RedisDemoNET5.Extensions
{
    public static class DistributedCacheExtenstions
    {
        public static async Task SetRecordAsync<T>(this IDistributedCache cache,
            string recordID,
            T data,
            TimeSpan? absoluteExpireTime = null,
            TimeSpan? unusedExpireTime = null)
        {
            //1. Setting options
            var options = new DistributedCacheEntryOptions();
            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60);
            options.SlidingExpiration = unusedExpireTime;


            var jsonData = JsonSerializer.Serialize(data);//2. Serialize Data
            await cache.SetStringAsync(recordID, jsonData, options);//3. Set
        }

        public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache, string recordID)
        {
            var jsonData = await cache.GetStringAsync(recordID);

            if (jsonData is null)
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(jsonData);//change to the type to it was given
        }
    }
}
