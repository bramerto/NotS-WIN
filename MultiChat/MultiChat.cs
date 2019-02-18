using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MultiChat
{
    public partial class MultiChat : Form
    {
        private TcpClient client;
        private NetworkStream networkStream;
        private Thread thread;

        public MultiChat()
        {
            InitializeComponent();
        }

        public delegate void setMessage(string input);

        private void updateChatBox(string input)
        {
            if (this.ChatBox.InvokeRequired)
            {
                
            }
            else
            {
                
            }
        }

        private void ListenBtn_Click(object sender, EventArgs e)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 9000);
            server.Start();
            
            ChatBox.AppendText("Listening for clients..." + Environment.NewLine);

            client = server.AcceptTcpClient();
            thread = new Thread(new ThreadStart(ReceiveData));
            thread.Start();
        }

        private void ReceiveData()
        {
            int bufferSize = 1024;
            string message;
            byte[] buffer = new byte[bufferSize];

            networkStream = client.GetStream();

            while (true)
            {
                int readBytes = networkStream.Read(buffer, 0, buffer.Length);
                message = Encoding.ASCII.GetString(buffer);

                if (message == "bye") break;

                // update textbox
            }
        }
    }
}
