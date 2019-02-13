using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace MultiChat
{
    public partial class MultiChat : Form
    {
        TcpClient tcpClient;
        NetworkStream networkStream;
        Thread thread;

        public MultiChat()
        {
            InitializeComponent();
        }

        public delegate void setMessage(string input);

        private void testMethod(string input)
        {
            if (this.ChatBox.InvokeRequired)
            {
                // var test = testDelegate(string);
                // this.Invoke(test, new object[], input);
            }
            else
            {
                // this.update ?
            }
        }

        private void ListenBtn_Click(object sender, EventArgs e)
        {
            var server = new TcpListener(IPAddress.Any, 9000);
            server.Start();
            
            ChatBox.AppendText("Listening for client..." + Environment.NewLine);

            Console.WriteLine("Connecting...");
            tcpClient = server.AcceptTcpClient();

            //thread = new Thread(ReceiveData());
            //thread.Start();
        }

        //private ThreadStart ReceiveData()
        //{
        //    int value;
        //    string text;
        //    byte[] arr = new byte[1024];

        //    networkStream = tcpClient.GetStream();

        //    while (true)
        //    {
        //       networkStream.Read(arr, 0, arr.Length);
        //       text = Encoding.ASCII.GetString(arr);

        //       if (text == "bye") break;
        //    }
        //}
    }
}
