using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MultiChat
{
    class Client : IDisposable
    {
        private readonly TcpClient client;
        private readonly MultiChat form;
        public int BufferSize { get; set; }
        private bool listening = true;
        public string id;

        /// <summary>
        /// Constructor of the client class
        /// </summary>
        /// <param name="client"></param>
        /// <param name="bufferSize"></param>
        /// <param name="form"></param>
        public Client(TcpClient client, int bufferSize, MultiChat form)
        {
            this.BufferSize = bufferSize;
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
                form.AddMessage("[client]: Connecting...");
                Task.Run(() => ReceiveData(this));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                form.AddMessage("[server]: Connection failed, please try again.");
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
            byte[] buffer = new byte[BufferSize];
            var stringBuilder = new StringBuilder();
            string message;

            form.AddMessage("[client]: Connected!");

            using (NetworkStream ns = rClient.Connection.GetStream())
            {
                while (listening)
                {
                    do
                    {
                        int readBytes = ns.Read(buffer, 0, BufferSize);
                        stringBuilder.AppendFormat("{0}", Encoding.ASCII.GetString(buffer, 0, readBytes));

                    } while (ns.DataAvailable);

                    message = stringBuilder.ToString();
                    stringBuilder.Clear();

                    // When server disconnects, stop listening
                    if (message.StartsWith("@close"))
                    {
                        form.AddMessage("[server]: Host disconnected");
                        break;
                    }

                    if (!string.IsNullOrEmpty(message)) form.AddMessage(message);
                }
                
                form.SetButtons(true, true);
            }
        }

        /// <summary>
        /// Disconnects the client and notifies the server by sending the message "@disconnect"
        /// </summary>
        public void Dispose()
        {
            listening = false;
            Send("@disconnect");
        }
    }
}
