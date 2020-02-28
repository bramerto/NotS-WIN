using System;
using System.Collections.ObjectModel;
using ProxyServices.Messages;
using ProxyServices.Models;

namespace ProxyServices
{
    public class CacheControl
    {
        private readonly Collection<CacheItem> _cachePool;
        public HttpResponse CachedResponse;

        public CacheControl()
        {
            _cachePool = new Collection<CacheItem>();
        }

        public bool SetCacheItem(HttpRequest request)
        {
            foreach (var cacheItem in _cachePool)
            {
                if (cacheItem.Url != request.Url || cacheItem.ExpireTime.CompareTo(DateTime.Now) < 0) continue;
                CachedResponse = cacheItem.Response;
                return true;
            }

            return false;
        }

        public void AddToCache(CacheItem item)
        {
            _cachePool.Add(item);
        }
    }
}
