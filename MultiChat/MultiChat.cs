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
        NetworkStream networkStream;
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
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 9000);
            tcpListener.Start();

            AddMessage("Listening for client.");

            tcpClient = tcpListener.AcceptTcpClient();
            thread = new Thread(new ThreadStart(ReceiveData));
            thread.Start();
        }

        private void ReceiveData()
        {
            int bufferSize = 2;
            string message = "";
            byte[] buffer = new byte[bufferSize];

            networkStream = tcpClient.GetStream();
            
            AddMessage("Connected!");

            while (true)
            {
                int readBytes = networkStream.Read(buffer, 0, bufferSize);
                message = Encoding.ASCII.GetString(buffer, 0, readBytes);

                if (message == "bye")
                    break;

                AddMessage(message);
            }

            buffer = Encoding.ASCII.GetBytes("bye");
            networkStream.Write(buffer, 0, buffer.Length);

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
            networkStream.Write(buffer, 0, buffer.Length);

            AddMessage(message);
            txtMessageToBeSend.Clear();
            txtMessageToBeSend.Focus();
        }
    }
}
