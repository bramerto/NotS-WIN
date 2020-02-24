using ProxyServices.Messages;
using System;
using System.Net.Sockets;
using System.Collections.ObjectModel;
using ProxyServices.Models;

namespace ProxyServices
{
    internal class Client
    {
        private readonly HttpRequest request;
        private HttpResponse response;
        private readonly TcpClient tcpClient;
        private readonly bool caching;

        private readonly Collection<CacheItem> _cachePool;

        public Client(HttpRequest message, bool caching)
        {
            request = message;
            tcpClient = new TcpClient();
            this.caching = caching;
            _cachePool = new Collection<CacheItem>();
        }

        public HttpResponse HandleConnection()
        {
            try
            {
                var message = request.Message;
                var urlSplit = request.URL.Split(':');
                var port = int.Parse(urlSplit[2].Split('/')[0]);
                var url = urlSplit[1].TrimStart('/');

                //TODO: add caching
                if (caching)
                {
                    Console.WriteLine("CHECKING CACHE...");

                    foreach (var cacheItem in _cachePool)
                    {
                        if (cacheItem.Url == url && cacheItem.ExpireTime.CompareTo(DateTime.Now) >= 0)
                        {
                            return cacheItem.Response;
                        }
                    }
                }

                tcpClient.Connect(url, port);

                var data = System.Text.Encoding.ASCII.GetBytes(message);
                var ns = tcpClient.GetStream();
                ns.Write(data, 0, data.Length);

                data = new byte[256];

                var bytes = ns.Read(data, 0, data.Length);
                var responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                response = new HttpResponse(responseData);

                ns.Close();
                tcpClient.Close();

                if (caching)
                {
                    Console.WriteLine("CACHING...");
                    _cachePool.Add(new CacheItem() { Url = url, ExpireTime = DateTime.Now.AddDays(30), Response = response });
                }

                return response;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
                return null;
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                return null;
            }
        }
    }
}
