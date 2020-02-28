using ProxyServices.Messages;
using System;
using System.Net.Sockets;
using ProxyServices.Models;

namespace ProxyServices
{
    public class Client : Proxy
    {
        private HttpResponse response;
        private readonly TcpClient tcpClient;
        private readonly CacheControl _cache;
        private readonly bool _caching;

        /// <summary>
        /// Instantiates the Client class
        /// </summary>
        /// <param name="caching"></param>
        public Client(bool caching)
        {
            tcpClient = new TcpClient();
            _caching = caching;
            _cache = new CacheControl();
        }

        /// <summary>
        /// Sends 
        /// </summary>
        /// <returns></returns>
        public HttpResponse HandleConnection(HttpRequest request)
        {
            try
            {
                if (!_caching) return SendRequest(request);
                return _cache.SetCacheItem(request) ? _cache.CachedResponse : SendRequest(request);
            }
            catch (ArgumentNullException e)
            {
                AddUiMessage(e.ToString(), "Error");
                return null;
            }
            catch (SocketException e)
            {
                AddUiMessage(e.ToString(), "Error");
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
            var url = request.ParseUrl();
            tcpClient.Connect(url, request.Port);

            var data = System.Text.Encoding.ASCII.GetBytes(request.Message);
            var ns = tcpClient.GetStream();
            ns.Write(data, 0, data.Length);

            data = new byte[256];

            var bytes = ns.Read(data, 0, data.Length);
            var responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

            ns.Close();
            tcpClient.Close();

            response = new HttpResponse(responseData);

            if (_caching)
            {
                _cache.AddToCache(new CacheItem() { Url = url, ExpireTime = DateTime.Now.AddDays(30), Response = response });
            }

            return response;
        }
    }
}
