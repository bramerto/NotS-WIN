using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MultiChat
{
    class Client : IDisposable
    {
        private TcpClient client;
        private MultiChat form;
        public int bufferSize { get; set; }
        private bool listening = true;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client"></param>
        /// <param name="username"></param>
        /// <param name="form"></param>
        public Client(TcpClient client, string username, MultiChat form)
        {
            bufferSize = 1024;
            this.client = client;
            this.form = form;
        }

        /// <summary>
        /// Gets the actual TcpClient
        /// </summary>
        public TcpClient Connection
        {
            get { return client; } set { }
        }

        /// <summary>
        /// Starts a thread for listening to incoming messages
        /// </summary>
        public void Connect()
        {
            try
            {
                form.AddMessage("Connecting...");

                Task.Run(() =>
                {
                    ReceiveData(this);
                });
            }
            catch
            {
                form.AddMessage("Connection failed, please try again.");
            }
        }

        /// <summary>
        /// Sends a message to the server
        /// </summary>
        /// <param name="message"></param>
        public void Send(string message)
        {
            NetworkStream network = client.GetStream();

            byte[] bytes = Encoding.ASCII.GetBytes(message);
            network.Write(bytes, 0, bytes.Length);

            form.AddMessage(message);
            
        }

        /// <summary>
        /// Starts an infinite loop that listens for new messages
        /// </summary>
        /// <param name="c"></param>
        private void ReceiveData(Client c)
        {
            byte[] bytes = new byte[bufferSize];
            string message = "";

            form.AddMessage("Connected!");

            // Using the network as long as it is listening
            using (NetworkStream network = c.Connection.GetStream())
            {
                while (listening)
                {
                    int bytesRead = network.Read(bytes, 0, bufferSize);
                    message = Encoding.ASCII.GetString(bytes, 0, bytesRead);
                    bytes = new byte[bufferSize];

                    // Handles disconnection when server disconnects and send the message "!close"
                    if (message.StartsWith("!close"))
                    {
                        form.AddMessage("Host disconnected.");
                        break;
                    }
                    else
                    {
                        form.AddMessage(message);
                    }
                }
                //form.Reset();
                //form.SetButtons(true, true);
            }
        }

        /// <summary>
        /// Disconnects the client and notifies the server by sending the message "!disconnect"
        /// </summary>
        public void Dispose()
        {
            listening = false;
            Send("!disconnect");
        }
    }
}
