using ProxyServices.Messages;
using System;

namespace ProxyServices.Models
{
    public class ProxyLog : EventArgs
    {
        public string Type { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public HttpMessage HttpMessage { get; set; }
    }
}