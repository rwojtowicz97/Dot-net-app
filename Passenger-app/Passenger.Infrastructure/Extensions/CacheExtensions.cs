using System;
using Microsoft.Extensions.Caching.Memory;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Extensions
{
    public static class CacheExtensions
    {
        public static void SetJwt(this IMemoryCache cache, Guid tokenId, JwtDto jwt)
            => cache.Set("key", jwt, TimeSpan.FromSeconds(5));

        public static JwtDto GetJwt(this IMemoryCache cache, Guid tokenId)
            => cache.Get<JwtDto>("key");

        private static string GetJwtKey(Guid tokenId)
            => $"jwt-{tokenId}";
    }
}