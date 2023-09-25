using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace BookMyShow.Services
{
    public static class CacheService
    {
        public static void SetData<T>(this IDistributedCache cache, string key, T data, TimeSpan? absolute = null)
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absolute ?? TimeSpan.FromMinutes(1)
            };
            string jsonString = JsonSerializer.Serialize(data);
            byte[] dataInBytes = Encoding.UTF8.GetBytes(jsonString);
            cache.Set(key, dataInBytes, options);
        }

        public static T GetData<T>(this IDistributedCache cache, string key)
        {
            string data = cache.GetString(key);
            if (data == null)
            {
                return default;
            }
            return JsonSerializer.Deserialize<T>(data);
        }
    }
}
