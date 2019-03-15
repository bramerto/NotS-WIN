using Proxy.Messages;
using ProxyServices.DataStructures;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class Server : IDisposable
    {
        private int _bufferSize;
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
                        TcpClient c = await listener.AcceptTcpClientAsync();
                        Console.WriteLine("Connected!");
                        
                        _ = Task.Run(() => HandleConnection(c));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR: " + ex.ToString());
                    }
                }
            });
        }
        private void HandleConnection(TcpClient socket)
        {
            byte[] buffer = new byte[_bufferSize];
            var stringBuilder = new StringBuilder();
            string message;

            using (NetworkStream ns = socket.GetStream())
            {
                while (listening)
                {
                    try
                    {
                        do
                        {
                            int readBytes = ns.Read(buffer, 0, _bufferSize);
                            stringBuilder.AppendFormat("{0}", Encoding.ASCII.GetString(buffer, 0, readBytes));

                        } while (ns.DataAvailable);

                        buffer = new byte[_bufferSize];

                        message = stringBuilder.ToString();
                        stringBuilder.Clear();

                        HttpRequest request = new HttpRequest(message);
                        request.SetRequest();

                        Client client = new Client(request);
                        client.HandleConnection();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR: " + ex.ToString());
                        listening = false;
                    }
                }
                ns.Close();
                socket.Close();
            }
        }

        public void Dispose()
        {
            listening = false;
            listener.Stop();
            Console.WriteLine("Closed connection");
        }
    }
}
