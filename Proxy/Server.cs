using ProxyServices.Messages;
using ProxyServices.Models;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ProxyServices
{
    public class Server : IDisposable
    {
        private readonly TcpListener _listener;
        private readonly int _bufferSize;
        private readonly bool caching;
        private readonly bool advertisementFilter;
        private readonly bool privacyFilter;

        private bool _listening;

        public ObservableCollection<ProxyLog> MessagesCollection;

        public Server(int port, int bufferSize, ProxyUIEventArgs args)
        {
            _bufferSize = bufferSize;
            _listening = true;
            _listener = new TcpListener(IPAddress.Any, port);

            caching = args.cacheEnabled;
            advertisementFilter = args.advertisementFilterEnabled;
            privacyFilter = args.privacyFilterEnabled;

            MessagesCollection = new ObservableCollection<ProxyLog>();
        }

        /// <summary>
        /// Starts the server
        /// </summary>
        public void Start()
        {
            try
            {
                _listener.Start();
                _ = Listen();
            }
            catch (Exception ex)
            {
                AddUiMessage(ex.ToString(), "Error");
            }
        }

        /// <summary>
        /// Start listening for incoming clients on a different thread
        /// </summary>
        public async Task Listen()
        {
            AddUiMessage("Listening...", "TCP");

            while (_listening)
            {
                try
                {
                    var c = await _listener.AcceptTcpClientAsync();
                    AddUiMessage("Client Connected!", "TCP");
                    _ = HandleConnection(c);
                }
                catch (Exception ex)
                {
                    AddUiMessage(ex.ToString(), "Error");
                    Dispose();
                }
            }
        }

        /// <summary>
        /// Handles the connection from a tcp client, reads the http message, sends a request to the client and writes it back to original tcp client.
        /// </summary>
        /// <param name="socket"></param>
        private async Task HandleConnection(TcpClient socket)
        {
            var buffer = new byte[_bufferSize];
            var stringBuilder = new StringBuilder();

            using (var ns = socket.GetStream())
            {
                while (_listening)
                {
                    try
                    {
                        do
                        {
                            var readBytes = ns.Read(buffer, 0, _bufferSize);
                            stringBuilder.AppendFormat("{0}", Encoding.ASCII.GetString(buffer, 0, readBytes));

                        } while (ns.DataAvailable);

                        var request = new HttpRequest(stringBuilder.ToString());
                        stringBuilder.Clear();

                        if (privacyFilter)
                        {
                            request.Headers["User-Agent"] = "Proxy";
                        }

                        var client = new Client(request, caching);
                        var response = client.HandleConnection();

                        //TODO: add ad filter to response here to replace pictures with placeholders
                        if (advertisementFilter)
                        {
                            Console.WriteLine("AD FILTERING...");
                        }

                        ns.Write(Encoding.ASCII.GetBytes(response.ToString()), 0, _bufferSize);
                    }
                    catch (Exception ex)
                    {
                        AddUiMessage(ex.ToString(),"Error");
                        Dispose();
                    }
                }
                ns.Close();
                socket.Close();
            }
        }

        private void AddUiMessage(string message, string type)
        {
            MessagesCollection.Add(new ProxyLog() { Message = message, Source = "Server", Type = type });
            Console.WriteLine(message);
        }

        public void Dispose()
        {
            _listening = false;
            _listener.Stop();
            AddUiMessage("Closed connection", "TCP");
        }
    }
}
