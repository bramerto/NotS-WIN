using System;
using System.Collections.ObjectModel;
using System.Linq;
using ProxyServices.Messages;
using ProxyServices.Models;

namespace ProxyServices
{
    public class CacheControl
    {
        private readonly Collection<CacheItem> _cachePool;

        public CacheControl()
        {
            _cachePool = new Collection<CacheItem>();
        }

        /// <summary>
        /// Sets the cached request from the memory pool if it has been found and not expired yet
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool SetCacheItem(HttpRequest request)
        {
            return _cachePool.Any(cacheItem => cacheItem.Url == request.Url && cacheItem.ExpireTime.CompareTo(DateTime.Now) >= 0);
        }

        /// <summary>
        /// Adds to cache if response header allows it
        /// </summary>
        /// <param name="item"></param>
        public void AddToCache(CacheItem item)
        {
            if (item.Response.Headers["Cache-Control"] == null || item.Response.Headers["Cache-Control"] != "no-cache")
            {
                _cachePool.Add(item);
            }
        }
    }
}
