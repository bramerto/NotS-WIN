﻿using System;
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
        public CacheItem GetCacheItem(HttpRequest request)
        {
            return _cachePool.FirstOrDefault(cacheItem => cacheItem.Url == request.Url && cacheItem.ExpireTime.CompareTo(DateTime.Now) >= 0);
        }

        /// <summary>
        /// Adds cache item to cache
        /// </summary>
        /// <param name="item"></param>
        public void AddToCache(CacheItem item)
        {
            _cachePool.Add(item);
        }
    }
}
