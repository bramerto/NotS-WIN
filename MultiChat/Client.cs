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
        public string id;

        /// <summary>
        /// Constructor of the client class
        /// </summary>
        /// <param name="client"></param>
        /// <param name="form"></param>
        public Client(TcpClient client, int bufferSize, MultiChat form)
        {
            this.bufferSize = bufferSize;
            this.client = client;
            this.form = form;

            Guid guid = Guid.NewGuid();
            id = guid.ToString();
        }

        /// <summary>
        /// Gets the TcpClient of client class
        /// </summary>
        public TcpClient Connection
        {
            get { return client; } set { }
        }

        /// <summary>
        /// Starts a new thread for listening to incoming messages
        /// </summary>
        public void Connect()
        {
            try
            {
                form.AddMessage("Connecting...");
                Task.Run(() => ReceiveData(this));
            }
            catch
            {
                form.AddMessage("Connection failed, please try again.");
            }
        }

        /// <summary>
        /// Sends a message to the networkstream from server
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
        /// Starts a loop that listens for new messages
        /// </summary>
        /// <param name="rClient"></param>
        private void ReceiveData(Client rClient)
        {
            byte[] buffer = new byte[bufferSize];
            var stringBuilder = new StringBuilder();
            string message;

            form.AddMessage("Connected!");

            using (NetworkStream stream = rClient.Connection.GetStream())
            {
                while (listening)
                {
                    do
                    {
                        int readBytes = stream.Read(buffer, 0, bufferSize);
                        stringBuilder.AppendFormat("{0}", Encoding.ASCII.GetString(buffer, 0, readBytes));

                    } while (stream.DataAvailable);

                    message = stringBuilder.ToString();
                    stringBuilder.Clear();

                    // When server disconnects, stop listening
                    if (message.StartsWith("!close"))
                    {
                        form.AddMessage("Host disconnected");
                        break;
                    }

                    if (!string.IsNullOrEmpty(message)) form.AddMessage(message);
                }
                form.ClientReset();
                form.SetButtons(true, true);
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
