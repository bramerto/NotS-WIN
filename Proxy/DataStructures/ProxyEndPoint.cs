using System.Net;

namespace ProxyServices.DataStructures
{
    class ProxyEndPoint
    {
        public ProxyEndPoint(IPAddress ipAddress, int port)
        {
            IpAddress = ipAddress;
            Port = port;
        }
        public IPAddress IpAddress { get; set; }
        public int Port { get; set; }
    }
}
