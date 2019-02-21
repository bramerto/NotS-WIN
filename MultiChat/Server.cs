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
        private int bufferSize;
		private TcpListener listener;
		private bool listening = true;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="port"></param>
		/// <param name="form"></param>
		public Server(int port, int bufferSize, MultiChat form)
		{
			this.bufferSize = bufferSize;
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
					TcpClient rClient = await listener.AcceptTcpClientAsync();
					Client client = new Client(rClient, bufferSize, form);

					clients.Add(client);
					Task.Run(() => ReceiveData(client));
				}
			});
		}

		/// <summary>
		/// Starts an infinite loop that listens for new messages for a specific client
		/// </summary>
		/// <param name="rClient"></param>
		private void ReceiveData(Client rClient)
		{
            byte[] buffer = new byte[bufferSize];
            var stringBuilder = new StringBuilder();
            string message;

			using (NetworkStream stream = rClient.Connection.GetStream())
			{
				while (listening)
				{
					try {
                        int bytesRead = stream.Read(buffer, 0, bufferSize);
                        message = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                        if (message.StartsWith("!disconnect"))
                        {
						    clients.Remove(rClient);
						    Broadcast("a client left.");
						    break;
					    }

						Broadcast(message, rClient);
						form.AddMessage(message);
					}
					catch (Exception e)
					{
						Console.WriteLine("Receiving data went wrong.");
					}
				}
				stream.Close();
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
                    using (NetworkStream ns = client.Connection.GetStream())
                    {
                        byte[] bytes = new byte[bufferSize];

                        bytes = Encoding.ASCII.GetBytes(message);
                        ns.Write(bytes, 0, bytes.Length);
                    }
                }
            }
		}

        /// <summary>
		/// Sends a message to all clients except self
		/// </summary>
		/// <param name="message"></param>
        private void Broadcast(string message)
        {
            foreach (Client client in clients)
            {
                using (NetworkStream ns = client.Connection.GetStream())
                {
                    byte[] bytes = new byte[bufferSize];

                    bytes = Encoding.ASCII.GetBytes(message);
                    ns.Write(bytes, 0, bytes.Length);
                }
            }
        }

        /// <summary>
        /// Notifies all clients that the server disconnected and stops listening
        /// </summary>
        public void Dispose()
		{
            Broadcast("!close");
            listening = false;
			clients = null;
			listener.Stop();
		}
	}
}
