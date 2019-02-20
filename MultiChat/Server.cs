using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MultiChat
{
    class Server : IDisposable
    {
        private List<Client> clients = new List<Client>();
        private MultiChat form;
        private int port;
        public int bufferSize { get; set; }
        private TcpListener listener;
        private bool listening = true;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="port"></param>
        /// <param name="form"></param>
        public Server(int port, MultiChat form)
        {
            bufferSize = 1024;
            this.port = port;
            this.form = form;
        }

        /// <summary>
        /// Starts the server
        /// </summary>
        public void Start()
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                Listen();
            }
            catch (Exception e)
            {
                form.AddMessage("Another server is already running!");
                //form.SetButtons(true, true);
            }
        }

        /// <summary>
        /// Starts a new thread that listens for new clients and starts a new thread for each client to listen for their messages
        /// </summary>
        public void Listen()
        {
            form.AddMessage("Listening for clients...");

            Task.Run(async () =>
            {
                while (listening)
                {
                    TcpClient c = await listener.AcceptTcpClientAsync();

                    Client client = new Client(c, "", form);

                    clients.Add(client);
                    Task.Run(() =>
                    {
                        ReceiveData(client);
                    });
                }
            });
        }

        /// <summary>
        /// Starts an infinite loop that listens for new messages for a specific client
        /// </summary>
        /// <param name="c"></param>
        private void ReceiveData(Client c)
        {
            string endMessage = "bye";
            string message = "";

            byte[] bytes = new byte[bufferSize];

            // Using the network as long as it is listening
            using (NetworkStream network = c.Connection.GetStream())
            {
                while (listening)
                {
                    try
                    {
                        int bytesRead = network.Read(bytes, 0, bufferSize);
                        message = Encoding.ASCII.GetString(bytes, 0, bytesRead);
                        bytes = new byte[bufferSize];

                        if (message == endMessage)
                        {
                            break;
                        }

                        string msg = "";

                       if (message == "bye")
                        {
                            msg = "a client left.";
                            clients.Remove(c);
                            Broadcast(msg, c);
                            form.AddMessage(msg);
                            break;
                        }

                        Broadcast(msg, c);
                        form.AddMessage(msg);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Receiving data went wrong.");
                    }
                }
                network.Close();
                c.Connection.Close();
            }
        }

        /// <summary>
        /// Sends a message to all clients except the one who sent it
        /// </summary>
        /// <param name="message"></param>
        /// <param name="c"></param>
        private void Broadcast(string message, Client c)
        {
            foreach (Client client in clients)
            {
                
                NetworkStream ns = client.Connection.GetStream();

                byte[] bytes = new byte[bufferSize];

                bytes = Encoding.ASCII.GetBytes(message);
                ns.Write(bytes, 0, bytes.Length);
                
            }
        }

        /// <summary>
        /// Notifies all clients that the server disconnected and stops listening
        /// </summary>
        public void Dispose()
        {
            foreach (Client client in clients)
            {
                using (NetworkStream ns = client.Connection.GetStream())
                {
                    byte[] bytes = new byte[bufferSize];

                    bytes = Encoding.ASCII.GetBytes("!close");
                    ns.Write(bytes, 0, bytes.Length);
                }
            }

            listening = false;
            clients = null;
            listener.Stop();

            //form.SetButtons(true, true);
        }
    }
}
