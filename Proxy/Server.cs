using ProxyServices.Messages;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ProxyServices
{
    public class Server : Proxy
    {
        private readonly TcpListener _listener;
        public readonly Client Client;
        private readonly int _bufferSize;
        private readonly bool caching;
        private readonly bool advertisementFilter;
        private readonly bool privacyFilter;
        private readonly byte[] _buffer;
        private readonly StringBuilder _stringBuilder;

        private bool _listening;

        /// <summary>
        /// Instantiates the server class to work with Start().
        /// </summary>
        /// <param name="port"></param>
        /// <param name="bufferSize"></param>
        /// <param name="args"></param>
        public Server(int port, int bufferSize, ProxyUIEventArgs args)
        {
            _bufferSize = bufferSize;
            _listening = true;
            _listener = new TcpListener(IPAddress.Any, port);
            _buffer = new byte[_bufferSize];
            _stringBuilder = new StringBuilder();
            
            caching = args.cacheEnabled;
            advertisementFilter = args.advertisementFilterEnabled;
            privacyFilter = args.privacyFilterEnabled;

            Client = new Client(caching);
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
                AddUiMessage(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Start listening for incoming clients on a different thread
        /// </summary>
        private async Task Listen()
        {
            AddUiMessage("Listening...", "TCP");

            while (_listening)
            {
                try
                {
                    var c = await _listener.AcceptTcpClientAsync();
                    AddUiMessage("Client Connected!", "TCP");
                    HandleConnection(c);
                }
                catch (Exception ex)
                {
                    AddUiMessage(ex.Message, "Error");
                }
            }
        }

        /// <summary>
        /// Handles the connection from a tcp client, reads the http message, sends a request to the client and writes it back to original tcp client.
        /// </summary>
        /// <param name="socket"></param>
        private async Task HandleConnection(TcpClient socket)
        {
            using (var ns = socket.GetStream())
            {
                if (_listening)
                {
                    var request = GetHttpRequest(ns);
                    SendRequest(request, ns);
                }
            }
        }

        private HttpRequest GetHttpRequest(NetworkStream ns)
        {
            do
            {
                var readBytes = ns.Read(_buffer, 0, _bufferSize);
                _stringBuilder.AppendFormat("{0}", Encoding.ASCII.GetString(_buffer, 0, readBytes));

            } while (ns.DataAvailable);

            var message = _stringBuilder.ToString();

            var request = new HttpRequest(message);
            _stringBuilder.Clear();

            if (privacyFilter)
            {
                request.Headers["User-Agent"] = "Proxy";
            }

            return request;
        }

        /// <summary>
        /// Sends request to client and gives it back to the original sender
        /// </summary>
        /// <param name="request"></param>
        /// <param name="ns"></param>
        private void SendRequest(HttpRequest request, NetworkStream ns)
        {
            var response = Client.HandleConnection(request);

            if (response == null) return;
            
            //TODO: add ad filter to response here to replace pictures with placeholders
            if (advertisementFilter)
            {
                Console.WriteLine("AD FILTERING...");
            }

            var message = response.Message;

            //TODO: write correct HttpResponse back
            ns.Write(Encoding.ASCII.GetBytes(message), 0, _bufferSize);
        }

        /// <summary>
        /// Disposes the Server and sets it to off
        /// </summary>
        public void Stop()
        {
            _listening = false;
            _listener.Stop();
            AddUiMessage("Closed connection", "TCP");
        }
    }
}
