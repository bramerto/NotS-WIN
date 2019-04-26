using Proxy.Messages;
using System;
using System.Net.Sockets;

namespace Proxy
{
    class Client
    {
        private readonly HttpRequest request;
        private HttpResponse response;
        private readonly TcpClient tcpClient;

        public Client(HttpRequest message)
        {
            request = message;
            tcpClient = new TcpClient();
        }

        public HttpResponse HandleConnection()
        {
            try
            {
                string message = request.Message;
                string[] UrlSplit = request.URL.Split(':');
                int port = Int32.Parse(UrlSplit[2].Split('/')[0]);
                string URL = UrlSplit[1].TrimStart('/');

                tcpClient.Connect(URL, port);

                byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                NetworkStream stream = tcpClient.GetStream();
                stream.Write(data, 0, data.Length);

                data = new byte[256];
                String responseData = String.Empty;

                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                response = new HttpResponse(responseData);

                stream.Close();
                tcpClient.Close();

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
