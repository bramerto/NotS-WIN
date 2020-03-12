﻿using ProxyServices.Messages;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using ProxyServices.Models;

namespace ProxyServices
{
    public class Client
    {
        private TcpClient tcpClient;
        private readonly CacheControl _cache;
        private readonly bool _caching;
        private readonly bool _contentFilter;

        private readonly byte[] _clientBuffer;
        private readonly byte[] _serverBuffer;

        public Client(byte[] serverBuffer, bool caching, bool contentFilter)
        {
            _caching = caching;
            _serverBuffer = serverBuffer;
            _contentFilter = contentFilter;
            _cache = new CacheControl();
            _clientBuffer = new byte[1];
        }

        /// <summary>
        /// Sends the request to host and returns it
        /// </summary>
        /// <returns></returns>
        public HttpResponse HandleConnection(HttpRequest request, NetworkStream clientStream)
        {
            try
            {
                using (tcpClient = new TcpClient())
                {
                    request.Headers.TryGetValue("Host", out var url);
                    tcpClient.Connect(url, 80);

                    var response = SendRequestToServer(tcpClient, request, clientStream);

                    if (_caching && response != null)
                    {
                        _cache.AddToCache(new CacheItem { Url = url, ExpireTime = DateTime.Now.AddDays(30), Response = response});
                    }

                    return response;
                }

            }
            catch (SocketException exception)
            {
                return null;
            }
            catch (IOException exception)
            {
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        private HttpResponse SendRequestToServer(TcpClient client, HttpRequest request, NetworkStream clientStream)
        {
            using (var ns = client.GetStream())
            {
                var isImage = request.AcceptIsVideoOrImage;
                var data = Encoding.ASCII.GetBytes(request.GetMessage());
                ns.Write(data, 0, data.Length);

                var messageBuilder = new StringBuilder();

                do
                {
                    var readBytes = ns.Read(_clientBuffer, 0, _clientBuffer.Length);
                    if (isImage)
                    {
                        if (_contentFilter)
                        {
                            var placeholder = File.ReadAllBytes("C:\\Users\\Bram\\Documents\\GitHub\\NotS\\Proxy\\O6CFo4d.jpg");
                            clientStream.Write(placeholder, 0, placeholder.Length);
                        }
                        else
                        {
                            clientStream.Write(_clientBuffer, 0, readBytes);
                        }
                    }
                    else
                    {
                        messageBuilder.AppendFormat("{0}", Encoding.ASCII.GetString(_clientBuffer, 0, readBytes));
                    }

                } while (ns.DataAvailable);

                if (isImage) return null;

                var response = new HttpResponse(messageBuilder.ToString());

                var message = response.GetMessage();
                var messageBytes = Encoding.ASCII.GetBytes(message);

                clientStream.Write(messageBytes, 0, messageBytes.Length);
                return response;
            }
        }
    }
}

