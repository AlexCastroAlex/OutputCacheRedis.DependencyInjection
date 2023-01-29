using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputCacheRedis.DependencyInjection
{
    public static class AddRedisOutputCacheServiceExtension
    {
        public static IServiceCollection AddRedisOutputCache(this IServiceCollection services, string RedisConnectionString)
        {
            ArgumentNullException.ThrowIfNull(services);
            ArgumentNullException.ThrowIfNull(RedisConnectionString);

            services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(RedisConnectionString));
            // Add required services        
            services.AddOutputCache();

            // Remove default IOutputCacheStore
            services.RemoveAll<IOutputCacheStore>();

            // Add custom IOutputCacheStore
            services.AddSingleton<IOutputCacheStore, RedisOutputCacheStore>();

            return services;
        }
    }
}
