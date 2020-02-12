using ProxyServices.Messages;
using ProxyServices.DataStructures;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ProxyServices
{
    public class Server : IDisposable
    {
        private int BufferSize;
        private readonly ProxyEndPoint EndPoint;
        private TcpListener Listener;
        private bool Listening = true;

        public Server(int port, int bufferSize)
        {
            EndPoint = new ProxyEndPoint(IPAddress.Any, port);
            BufferSize = bufferSize;
        }

        /// <summary>
        /// Starts the server
        /// </summary>
        public void Start()
        {
            try
            {
                Listener = new TcpListener(EndPoint.IpAddress, EndPoint.Port);
                Listener.Start();
                Listen();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.ToString());
            }
        }

        /// <summary>
        /// Start listening for incoming clients on a different thread
        /// </summary>
        public void Listen()
        {
            _ = Task.Run(async () =>
            {
                Console.WriteLine("Listening...");

                while (Listening)
                {
                    try
                    {
                        TcpClient c = await Listener.AcceptTcpClientAsync();
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

        /// <summary>
        /// Handles the connection from a tcpclient, reads the http message, sends a request to the client and writes it back to original tcpclient.
        /// </summary>
        /// <param name="socket"></param>
        private void HandleConnection(TcpClient socket)
        {
            byte[] buffer = new byte[BufferSize];
            var stringBuilder = new StringBuilder();
            string message;

            using (NetworkStream ns = socket.GetStream())
            {
                while (Listening)
                {
                    try
                    {
                        do
                        {
                            int readBytes = ns.Read(buffer, 0, BufferSize);
                            stringBuilder.AppendFormat("{0}", Encoding.ASCII.GetString(buffer, 0, readBytes));

                        } while (ns.DataAvailable);

                        message = stringBuilder.ToString();
                        stringBuilder.Clear();

                        HttpRequest request = new HttpRequest(message);
                        // add privacy filter by changing the request headers for privacy

                        Client client = new Client(request);
                        HttpResponse response = client.HandleConnection();

                        //add ad filter to response here to replace pictures with placeholders.

                        //write back to stream
                        //ns.Write(response, 0, BufferSize);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR: " + ex.ToString());
                        Dispose();
                    }
                }
                ns.Close();
                socket.Close();
            }
        }

        public void Dispose()
        {
            Listening = false;
            Listener.Stop();
            Console.WriteLine("Closed connection");
        }
    }
}
