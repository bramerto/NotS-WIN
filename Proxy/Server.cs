using ProxyServices.DataStructures;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Proxy
{
    public class Server : IDisposable
    {
        private readonly int _bufferSize;
        private ProxyEndPoint endPoint;
        private TcpListener listener;
        private bool listening = true;

        public Server(int port, int bufferSize)
        {
            endPoint = new ProxyEndPoint(IPAddress.Any, port);
            _bufferSize = bufferSize;
        }
        public void Start()
        {
            try
            {
                listener = new TcpListener(endPoint._ipAddress, endPoint._port);
                listener.Start();
                Listen();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.ToString());
            }
        }

        public void Listen()
        {
            Task.Run(async () =>
            {
                Console.WriteLine("Listening...");

                while (listening)
                {
                    try
                    {
                        Socket c = await listener.AcceptSocketAsync();
                        Console.WriteLine("Connected!");
                        Client client = new Client(c);
                        _ = Task.Run(() => client.HandleConnection());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR: " + ex.ToString());
                    }
                }
            });
        }

        public void Dispose()
        {
            listening = false;
            listener.Stop();
            Console.WriteLine("Stopped listening");
        }
    }
}
