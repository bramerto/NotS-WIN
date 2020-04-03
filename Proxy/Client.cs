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

        private readonly int _serverBufferSize;

        private const string PlaceHolderPath = "..\\..\\..\\Proxy\\O6CFo4d.jpg";

        public Client(int serverBufferSize, bool contentFilter)
        {
            _serverBufferSize = serverBufferSize;
            _contentFilter = contentFilter;
        }

        /// <summary>
        /// Sends the request to host and returns it
        /// </summary>
        /// <returns></returns>
        public MemoryStream HandleConnection(HttpRequest request, NetworkStream clientStream)
        {
            try
            {
                using (tcpClient = new TcpClient())
                {
                    var url = request.GetHostUrl();
                    tcpClient.Connect(url, 80);

                    return SendRequestToServer(tcpClient, request, clientStream);
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
        /// <param name="server"></param>
        /// <param name="request"></param>
        /// <param name="clientStream"></param>
        /// <returns></returns>
        private MemoryStream SendRequestToServer(TcpClient server, HttpRequest request, NetworkStream clientStream)
        {
            using (var ns = server.GetStream())
            {
                var memoryStream = new MemoryStream();
                var readBuffer = new byte[_serverBufferSize];

                //Send request to server
                var data = Encoding.ASCII.GetBytes(request.GetMessage());
                ns.Write(data, 0, data.Length);

                if (_contentFilter && request.AcceptIsVideoOrImage)
                {
                    //Set placeholder if content
                    var placeholder = File.ReadAllBytes(PlaceHolderPath);
                    clientStream.Write(placeholder, 0, placeholder.Length);
                }
                else
                {
                    do
                    {
                        var readBytes = ns.Read(readBuffer, 0, readBuffer.Length);

                        //write response back to server
                        clientStream.Write(readBuffer, 0, readBytes);
                        memoryStream.Write(readBuffer, 0, readBytes);
                        ByteManagement.AwaitNextByteResult(ns);

                    } while (ns.DataAvailable);
                }

                return memoryStream;
            }
        }
    }
}

