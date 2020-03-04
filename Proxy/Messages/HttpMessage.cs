using System.Collections.Concurrent;

namespace ProxyServices.Messages
{
    public class HttpMessage
    {
        public string Message { get; set; }
        public ConcurrentDictionary<string, string> Headers { get; protected set; }
        public string Version { get; protected set; }
    }
}
