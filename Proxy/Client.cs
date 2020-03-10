using ProxyServices.Messages;
using System;
using System.Net.Sockets;
using System.Text;
using ProxyServices.Models;

namespace ProxyServices
{
    public class Client
    {
        private HttpResponse response;
        private TcpClient tcpClient;
        private readonly CacheControl _cache;
        private readonly bool _caching;

        public Client(bool caching)
        {
            _caching = caching;
            _cache = new CacheControl();
        }

        /// <summary>
        /// Sends the request to host and returns it
        /// </summary>
        /// <returns></returns>
        public HttpResponse HandleConnection(HttpRequest request)
        {
            try
            {
                if (!_caching) return SendRequest(request);
                return _cache.SetCacheItem(request) ? _cache.CachedResponse : SendRequest(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        /// <summary>
        /// Sends request given by request url and gets the response, caches it if enabled.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private HttpResponse SendRequest(HttpRequest request)
        {
            using (tcpClient = new TcpClient())
            {
                request.Headers.TryGetValue("Host", out var url);

                try
                {
                    tcpClient.Connect(url, 80);
                }
                catch (Exception e)
                {
                    Console.WriteLine("No URL");
                    return null;
                }

                using (var ns = tcpClient.GetStream())
                {
                    var data = Encoding.ASCII.GetBytes(request.Message); //TODO: set request class to string instead of message
                    ns.Write(data, 0, data.Length);

                    var clientBuffer = new byte[256];
                    var stringBuilder = new StringBuilder();

                    do
                    {
                        var readBytes = ns.Read(clientBuffer, 0, clientBuffer.Length);
                        stringBuilder.AppendFormat("{0}", Encoding.ASCII.GetString(clientBuffer, 0, readBytes));

                    } while (ns.DataAvailable);

                    var message = stringBuilder.ToString();

                    response = new HttpResponse(message);
                }

                if (_caching)
                {
                    _cache.AddToCache(new CacheItem() { Url = url, ExpireTime = DateTime.Now.AddDays(30), Response = response });
                }

                return response;
            }
        }
    }
}
