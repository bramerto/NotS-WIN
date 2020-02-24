using System;
using ProxyServices.Messages;

namespace ProxyServices.Models
{
    internal class CacheItem
    {
        public string Url { get; set; }
        public DateTime ExpireTime { get; set; }
        public HttpResponse Response { get; set; }
    }
}
