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
		private readonly MultiChat form;
		private readonly int port;
        private readonly int bufferSize;
		private TcpListener listener;
		private bool listening = true;

        /// <summary>
        /// Constructor of the Server class
        /// </summary>
        /// <param name="port"></param>
        /// <param name="bufferSize"></param>
        /// <param name="form"></param>
        public Server(int port, int bufferSize, MultiChat form)
		{
			this.bufferSize = bufferSize;
			this.port = port;
			this.form = form;
		}

		/// <summary>
		/// Starts the server class so clients can connect to it
		/// </summary>
		public void Start()
		{
			try
			{
				listener = new TcpListener(IPAddress.Any, port);
				listener.Start();
				Listen();
			}
			catch (Exception ex)
			{
                Console.WriteLine(ex.ToString());
				form.AddMessage("[client]: Another server is already running!");
                form.SetButtons(true, true);
            }
		}

		/// <summary>
		/// Starts a new thread that listens for new clients and starts a new thread for each client to listen to their messages
		/// </summary>
		public void Listen()
		{
			form.AddMessage("[server]: Listening for clients...");

			Task.Run(async () =>
			{
				while (listening)
				{
					TcpClient rClient = await listener.AcceptTcpClientAsync();
					Client client = new Client(rClient, bufferSize, form);

					clients.Add(client);
					Task.Run(() => ReceiveData(client));
				}
			});
		}

		/// <summary>
		/// Starts a loop that listens for new messages for a client
		/// </summary>
		/// <param name="rClient"></param>
		private void ReceiveData(Client rClient)
		{
            byte[] buffer = new byte[bufferSize];
            var stringBuilder = new StringBuilder();
            string message;

			using (NetworkStream ns = rClient.Connection.GetStream())
			{
				while (listening)
				{
					try {

                        // as long as data is available in the stream from a single message. Read it through and append it to a string builder.
                        do
                        {
                            int readBytes = ns.Read(buffer, 0, bufferSize);
                            stringBuilder.AppendFormat("{0}", Encoding.ASCII.GetString(buffer, 0, readBytes));

                        } while (ns.DataAvailable);

                        buffer = new byte[bufferSize];

                        message = stringBuilder.ToString();
                        stringBuilder.Clear();

                        // broadcast when a client left
                        if (message.StartsWith("@disconnect"))
                        {
                            string leftMsg = "[server]: a client left.";

                            clients.Remove(rClient);
						    Broadcast(leftMsg, rClient);
                            form.AddMessage(leftMsg);
                            break;
					    }

						Broadcast(message, rClient);
						form.AddMessage(message);
					}
					catch (Exception ex)
					{
                        Console.WriteLine(ex.ToString());
                        form.AddMessage("Receiving data went wrong.");
                        listening = false;
					}
				}
                ns.Close();
                rClient.Connection.Close();
            }
		}

		/// <summary>
		/// Sends a message to all clients except self
		/// </summary>
		/// <param name="message"></param>
		/// <param name="rClient"></param>
		private void Broadcast(string message, Client rClient)
		{
			foreach (Client client in clients)
			{
                if (client.id != rClient.id)
                {
                    NetworkStream ns = client.Connection.GetStream();
                    
                    byte[] bytes = new byte[bufferSize];

                    bytes = Encoding.ASCII.GetBytes(message);
                    ns.Write(bytes, 0, bytes.Length);
                }
            }
		}

        /// <summary>
		/// Sends a message to all clients in the list of the server
		/// </summary>
		/// <param name="message"></param>
        private void Broadcast(string message)
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
            Broadcast("@close");
            listening = false;
			clients = null;
			listener.Stop();
            form.SetButtons(true, true);
        }
	}
}
