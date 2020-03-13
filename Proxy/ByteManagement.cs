using System.Net.Sockets;
using System.Threading;

namespace ProxyServices
{
    internal class ByteManagement
    {
        public static void AwaitNextByteResult(NetworkStream ns)
        {
            if (!ns.DataAvailable) Thread.Sleep(50);
        }
    }
}
