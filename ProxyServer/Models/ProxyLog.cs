using Proxy.Messages;

namespace ProxyServer
{
    class ProxyLog
    {
        public string Type { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public IHttpMessage HttpMessage { get; set; }
    }
}