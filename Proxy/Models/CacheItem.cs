using System;
using System.IO;
using ProxyServices.Messages;

namespace ProxyServices.Models
{
    public class CacheItem
    {
        public string Url { get; set; }
        public DateTime ExpireTime { get; set; }
        public MemoryStream ResponseBytes { get; set; }
        public HttpResponse Response { get; set; }
    }
}
