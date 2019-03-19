

using System.Net;
using System.Net.Sockets;

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
