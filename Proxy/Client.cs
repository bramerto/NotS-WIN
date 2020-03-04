using ProxyServices.Messages;
using System;
using System.Net.Sockets;
using ProxyServices.Models;

namespace ProxyServices
{
    public class Client : Proxy
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
            catch (ArgumentNullException ex)
            {
                AddUiMessage(ex);
                return null;
            }
            catch (SocketException ex)
            {
                AddUiMessage(ex);
                return null;
            }
            catch (Exception ex)
            {
                AddUiMessage(ex);
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
            tcpClient = new TcpClient();
            if (request.Headers["Host"] == null) return null;

            var url = request.Headers["Host"];
            tcpClient.Connect(url, 80);
            

            using (var ns = tcpClient.GetStream())
            {
                var data = System.Text.Encoding.ASCII.GetBytes(request.Message);
                ns.Write(data, 0, data.Length);

                data = new byte[256];

                var bytes = ns.Read(data, 0, data.Length);
                var responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                response = new HttpResponse(responseData);
            }

            tcpClient.Close();


            if (_caching)
            {
                _cache.AddToCache(new CacheItem() { Url = url, ExpireTime = DateTime.Now.AddDays(30), Response = response });
            }

            return response;
        }
    }
}
