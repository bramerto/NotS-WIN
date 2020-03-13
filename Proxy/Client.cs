using ProxyServices.Messages;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ProxyServices
{
    public class Client
    {
        private TcpClient tcpClient;
        private readonly bool _contentFilter;

        private readonly byte[] _clientBuffer;
        private readonly byte[] _serverBuffer;
        private readonly int _serverBufferSize;

        private const string PlaceHolderPath = "C:\\Users\\Bram\\Documents\\GitHub\\NotS\\Proxy\\O6CFo4d.jpg";

        public Client(int serverBufferSize, bool contentFilter)
        {
            _serverBufferSize = serverBufferSize;
            _serverBuffer = new byte[serverBufferSize];
            _contentFilter = contentFilter;
            _clientBuffer = new byte[1];
        }

        /// <summary>
        /// Sends the request to host and returns it
        /// </summary>
        /// <returns></returns>
        public byte[] HandleConnection(HttpRequest request, NetworkStream clientStream)
        {
            try
            {
                using (tcpClient = new TcpClient())
                {
                    var url = request.GetHostUrl();
                    tcpClient.Connect(url, 80);

                    var response = SendRequestToServer(tcpClient, request, clientStream);

                    return response;
                }
            }
            catch (SocketException)
            {
                return null;
            }
            catch (IOException)
            {
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        /// <summary>
        /// Sends request to server and directs reply back to client stream
        /// </summary>
        /// <param name="client"></param>
        /// <param name="request"></param>
        /// <param name="clientStream"></param>
        /// <returns></returns>
        private byte[] SendRequestToServer(TcpClient client, HttpRequest request, NetworkStream clientStream)
        {
            using (var memoryStream = new MemoryStream())
            using (var ns = client.GetStream())
            {
                var isImage = request.AcceptIsVideoOrImage;
                var data = Encoding.ASCII.GetBytes(request.GetMessage());
                ns.Write(data, 0, data.Length);

                do
                {
                    var readBytes = ns.Read(_clientBuffer, 0, _clientBuffer.Length);
                    
                    if (_contentFilter && isImage)
                    {
                        var placeholder = File.ReadAllBytes(PlaceHolderPath);
                        clientStream.Write(placeholder, 0, placeholder.Length);
                    }
                    else
                    {
                        clientStream.Write(_clientBuffer, 0, readBytes);
                        memoryStream.Write(_clientBuffer, 0, readBytes);
                    }

                } while (ns.DataAvailable);

                var messageBytes = memoryStream.ToArray();

                return messageBytes;
            }
        }
    }
}

