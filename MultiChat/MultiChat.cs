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
        TcpClient tcpClient;
        NetworkStream stream;
        Thread thread;

        protected delegate void UpdateDisplayDelegate(string message);

        public MultiChat()
        {
            InitializeComponent();
        }

        private void AddMessage(string message)
        {
            if (listChats.InvokeRequired)
            {
                listChats.Invoke(new UpdateDisplayDelegate(UpdateDisplay), new object[] { message });
            }
            else
            {
                UpdateDisplay(message);
            }
        }

        private void UpdateDisplay(string message)
        {
            listChats.Items.Add(message);
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            IPAddress ip = IPAddress.Any;
            TcpListener tcpListener = new TcpListener(ip, 9000);
            thread = new Thread(new ThreadStart(tcpListener.Start));

            thread.Start();

            AddMessage("Chat server started on: " + ip.ToString());
            AddMessage("Listening for client.");
           

            tcpClient = tcpListener.AcceptTcpClient();
            thread = new Thread(new ThreadStart(ReceiveData));
            thread.Start();
        }

        private void ReceiveData()
        {
            int bufferSize = 2;
            var message = new StringBuilder(); ;
            byte[] buffer = new byte[bufferSize];

            stream = tcpClient.GetStream();
            
            AddMessage("Connected!");

            while (true) {
                do
                {
                    int readBytes = stream.Read(buffer, 0, bufferSize);
                    message.AppendFormat("{0}", Encoding.ASCII.GetString(buffer, 0, readBytes));
                }
                while (stream.DataAvailable);

                if (message.ToString() == "bye") break;

                AddMessage(message.ToString());
                message.Clear();
            }

            buffer = Encoding.ASCII.GetBytes("bye");
            stream.Write(buffer, 0, buffer.Length);

            // cleanup:
            //networkStream.Close();
            //tcpClient.Close();

            AddMessage("Connection closed");
        }

        private void btnConnectWithServer_Click(object sender, EventArgs e)
        {
            AddMessage("Connecting...");

            tcpClient = new TcpClient(txtChatServerIP.Text, 9000);
            thread = new Thread(new ThreadStart(ReceiveData));
            thread.Start();
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            string message = txtMessageToBeSend.Text;

            byte[] buffer = Encoding.ASCII.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);

            AddMessage(message);
            txtMessageToBeSend.Clear();
            txtMessageToBeSend.Focus();
        }
    }
}
