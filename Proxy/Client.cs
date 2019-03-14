

using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Proxy
{
    class Client
    {
        private Socket _socket;
        public Client (Socket socket)
        {
            _socket = socket;
        }
        public void HandleConnection()
        {
            Console.WriteLine("Handling Connection!");
            //bool recvRequest = true;
            //string EOL = "rn";

            //string requestPayload = "";
            //string requestTempLine = "";
            //List<string> requestLines = new List<string>();
            //byte[] requestBuffer = new byte[1];
            //byte[] responseBuffer = new byte[1];

            //requestLines.Clear();

            //try
            //{
            //    //State 0: Handle Request from Client
            //    while (recvRequest)
            //    {
            //        _socket.Receive(requestBuffer);
            //        string fromByte = Encoding.ASCII.GetString(requestBuffer);
            //        requestPayload += fromByte;
            //        requestTempLine += fromByte;

            //        if (requestTempLine.EndsWith(EOL))
            //        {
            //            requestLines.Add(requestTempLine.Trim());
            //            requestTempLine = "";
            //        }

            //        if (requestPayload.EndsWith(EOL + EOL))
            //        {
            //            recvRequest = false;
            //        }
            //    }
            //    Console.WriteLine("Raw Request Received...");
            //    Console.WriteLine(requestPayload);

            //    //State 1: Rebuilding Request Information and Create Connection to Destination Server
            //    string remoteHost = requestLines[0].Split(' ')[1].Replace("http://", "").Split('/')[0];
            //    string requestFile = requestLines[0].Replace("http://", "").Replace(remoteHost, "");
            //    requestLines[0] = requestFile;

            //    requestPayload = "";
            //    foreach (string line in requestLines)
            //    {
            //        requestPayload += line;
            //        requestPayload += EOL;
            //    }

            //    Socket destServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //    destServerSocket.Connect(remoteHost, 80);

            //    //State 2: Sending New Request Information to Destination Server and Relay Response to Client
            //    destServerSocket.Send(Encoding.ASCII.GetBytes(requestPayload));

            //    //Console.WriteLine("Begin Receiving Response...");
            //    while (destServerSocket.Receive(responseBuffer) != 0)
            //    {
            //        //Console.Write(ASCIIEncoding.ASCII.GetString(responseBuffer));
            //        _socket.Send(responseBuffer);
            //    }

            //    destServerSocket.Disconnect(false);
            //    destServerSocket.Dispose();
            //    _socket.Disconnect(false);
            //    _socket.Dispose();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Error Occured: " + e.Message);
            //    //Console.WriteLine(e.StackTrace);
            //}
        }
    }
}
