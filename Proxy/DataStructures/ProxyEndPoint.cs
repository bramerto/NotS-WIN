

using System.Net;
using System.Net.Sockets;

namespace ProxyServices.DataStructures
{
    class ProxyEndPoint
    {
        public ProxyEndPoint(IPAddress ipAddress, int port)
        {
            _ipAddress = ipAddress;
            _port = port;
        }
        public IPAddress _ipAddress { get; set; }
        public int _port { get; set; }
    }
}
