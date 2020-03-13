using ProxyServices.Messages;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProxyServices.Models;

namespace ProxyServices
{
    public class Server : Proxy
    {
        private readonly TcpListener _listener;
        private readonly int _bufferSize;
        private readonly bool advertisementFilter;
        private readonly bool caching;
        private readonly bool privacyFilter;
        private readonly byte[] _buffer;
        private readonly CacheControl _cache;

        private readonly SynchronizationContext uiContext = SynchronizationContext.Current;

        private bool _listening;

        public Server(int port, int bufferSize, ProxyUiEventArgs args)
        {
            _bufferSize = bufferSize;
            _listening = true;
            _listener = new TcpListener(IPAddress.Any, port);
            _buffer = new byte[_bufferSize];

            advertisementFilter = args.AdvertisementFilterEnabled;
            privacyFilter = args.PrivacyFilterEnabled;
            caching = args.CacheEnabled;
            _cache = new CacheControl();
        }

        /// <summary>
        /// Starts the server.
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
                AddUiMessage(ex);
            }
        }

        /// <summary>
        /// Start listening for incoming clients on a different thread
        /// </summary>
        private async Task Listen()
        {
            AddUiMessage("Proxy Started", "TCP");
            while (_listening)
            {
                try
                {
                    var c = await _listener.AcceptTcpClientAsync();
                    _ = Task.Run(() => HandleConnection(c));
                }
                catch (Exception ex)
                {
                    AddUiMessage(ex);
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
                if (!_listening) return;

                var request = GetHttpRequest(ns);
                uiContext.Send(x => AddUiMessage(request.GetHeaders(), "Request"), null);

                var byteResponse = HandleCache(request, ns);
                SetCache(byteResponse, request);
            }
        }

        /// <summary>
        /// Gets the HTTP request from stream
        /// </summary>
        /// <param name="ns"></param>
        /// <returns></returns>
        private HttpRequest GetHttpRequest(NetworkStream ns)
        {
            var stringBuilder = new StringBuilder();
            do
            {
                var readBytes = ns.Read(_buffer, 0, _bufferSize);
                stringBuilder.AppendFormat("{0}", Encoding.ASCII.GetString(_buffer, 0, readBytes));

            } while (ns.DataAvailable);

            var message = stringBuilder.ToString();
            stringBuilder.Clear();

            var request = new HttpRequest(message);

            if (privacyFilter && request.Headers["User-Agent"] != null)
            {
                request.Headers["User-Agent"] = "Proxy";
            }

            return request;
        }

        /// <summary>
        /// Gets request from client or out of the cache pool
        /// </summary>
        /// <param name="request"></param>
        /// <param name="ns"></param>
        /// <returns></returns>
        private byte[] HandleCache(HttpRequest request, NetworkStream ns)
        {
            if (!caching)
            {
                return SentWithClient(request, ns);
            }
            var cacheItem = _cache.GetCacheItem(request);

            return cacheItem == null ? SentWithClient(request, ns) : SentCached(cacheItem, ns);
        }

        private byte[] SentWithClient(HttpRequest request, NetworkStream ns)
        {
            var client = new Client(_bufferSize, advertisementFilter);
            var bytes = client.HandleConnection(request, ns);
            var response = new HttpResponse(bytes);
            uiContext.Send(x => AddUiMessage(response.GetHeaders(), "Response"), null);
            return bytes;
        }

        private byte[] SentCached(CacheItem cacheItem, NetworkStream ns)
        {
            var byteResponse = cacheItem.ResponseBytes;
            var response = new HttpResponse(byteResponse);

            ns.Write(byteResponse, 0, _bufferSize);

            uiContext.Send(x => AddUiMessage(response.GetHeaders(), "Cached Response"), null);
            return byteResponse;
        }

        /// <summary>
        /// Set response to HttpResponse and set to cache 
        /// </summary>
        /// <param name="byteResponse"></param>
        /// <param name="request"></param>
        private void SetCache(byte[] byteResponse, HttpRequest request)
        {
            if (byteResponse == null) return;
            var response = new HttpResponse(byteResponse);
            if (caching)
            {
                _cache.AddToCache(new CacheItem
                {
                    Url = request.GetHostUrl(),
                    ExpireTime = DateTime.Now.AddDays(30),
                    Response = response,
                    ResponseBytes = byteResponse,
                });
            }
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
