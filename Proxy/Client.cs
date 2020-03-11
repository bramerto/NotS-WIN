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
        private readonly byte[] _clientBuffer;

        public Client(bool caching)
        {
            _caching = caching;
            _cache = new CacheControl();
            _clientBuffer = new byte[4096];
        }

        /// <summary>
        /// Sends the request to host and returns it
        /// </summary>
        /// <returns></returns>
        public void HandleConnection(HttpRequest request, NetworkStream clientStream)
        {
            try
            {
                SendRequest(request, clientStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Sends request given by request url and gets the response, caches it if enabled.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private void SendRequest(HttpRequest request, NetworkStream clientStream)
        {
            using (tcpClient = new TcpClient())
            {
                request.Headers.TryGetValue("Host", out var url);

                try
                {
                    tcpClient.Connect(url ?? throw new InvalidOperationException(), 80);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                using (var ns = tcpClient.GetStream())
                {
                    var data = Encoding.ASCII.GetBytes(request.GetMessage());
                    ns.Write(data, 0, data.Length);

                    var stringBuilder = new StringBuilder();

                    do
                    {
                        var readBytes = ns.Read(_clientBuffer, 0, _clientBuffer.Length);
                        if (!request.Headers["Accept-Encoding"].Contains("img"))
                        {
                            clientStream.Write(_clientBuffer, 0, readBytes);
                        }
                        else
                        {
                            stringBuilder.AppendFormat("{0}", Encoding.ASCII.GetString(_clientBuffer, 0, readBytes));
                        }

                    } while (ns.DataAvailable);

                    var message = stringBuilder.ToString();

                    response = new HttpResponse(message);
                }

                if (_caching)
                {
                    _cache.AddToCache(new CacheItem() { Url = url, ExpireTime = DateTime.Now.AddDays(30), Response = response });
                }
            }
        }
    }
}
