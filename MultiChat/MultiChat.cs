using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace MultiChat
{
    public partial class MultiChat : Form
    {
        private Client client;
        private Server server;
        private int localPort;
        private int bufferSize;

        protected delegate void UpdateChatDelegate(string message);
        protected delegate void SetButtonsDelegate(bool server, bool enable);
        
        public MultiChat()
        {
            localPort = 3000;
            InitializeComponent();

            // Enable to send a message with enter
            txtMessageToBeSend.KeyDown += (sender, args) => {
                if (args.KeyCode == Keys.Return)
                    btnSendMessage.PerformClick();
            };
        }

        // Delegate functions
        public void AddMessage(string message)
        {
            if (listChats.InvokeRequired)
                listChats.Invoke(new UpdateChatDelegate(UpdateChat), new object[] { ">> " + message });
            else
                UpdateChat("<< " + message);
        }

        private void UpdateChat(string message)
        {
            int nItems = (int)(listChats.Height / listChats.ItemHeight);
            listChats.TopIndex = listChats.Items.Count - nItems;
            listChats.Items.Add(message);
        }

        public void SetButtons(bool server, bool enable)
        {
            if (txtMessageToBeSend.InvokeRequired)
                listChats.Invoke(new SetButtonsDelegate(UpdateButtons), new object[] { server, enable });
            else
                UpdateButtons(server, enable);
        }

        private void UpdateButtons(bool server, bool enable)
        {
            txtChatServerIP.ReadOnly = !enable;
            btnConnectWithServer.Enabled = enable;
            btnListen.Enabled = enable;
            btnDisconnect.Enabled = !enable;

            if (server)
            {
                txtMessageToBeSend.ReadOnly = !enable;
                btnSendMessage.Enabled = enable;
            }
        }

        // Client methods
        private void Disconnect()
        {
            if (server != null)
            {
                try
                {
                    server.Dispose();
                    server = null;
                }
                catch (Exception ex)
                {
                    AddMessage(ex.ToString());
                }
            }
            else if (client != null)
            {
                try
                {
                    client.Dispose();
                    client = null;
                }
                catch (Exception ex)
                {
                    AddMessage(ex.ToString());
                }
            }
        }

        private void validateBufferSize(string bufferInput)
        {
            if (!String.IsNullOrEmpty(bufferInput) && int.TryParse(bufferInput, out int n) && n > 1 && n < int.MaxValue)
            {
                bufferSize = n;
            }
            else
            {
                AddMessage("Invalid buffersize");
            }
        }

        // Events
        private void btnListen_Click(object sender, EventArgs e)
        {
            validateBufferSize(bufferSizeInput.Text);
            server = new Server(localPort, bufferSize,  this);
            server.Start();
        }

        private void btnConnectWithServer_Click(object sender, EventArgs e)
        {
            try
            {
                validateBufferSize(bufferSizeInput.Text);
                TcpClient c = new TcpClient(txtChatServerIP.Text, localPort);
                client = new Client(c, bufferSize, this);
                client.Connect();
            }
            catch (Exception ex)
            {
                AddMessage("Connection failed.");
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            string message = txtMessageToBeSend.Text;

            if (client == null)
                AddMessage("There is no connection yet");
            else if
                (String.IsNullOrEmpty(message)) AddMessage("Type a message first");
            else
            {
                // Disables the ability to send "!close" or "!disconnect 
                if (!message.StartsWith("!"))
                {
                    client.Send(message);
                }

                txtMessageToBeSend.Clear();
                txtMessageToBeSend.Focus();
            }
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void MultiChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            Disconnect();
        }
    }
}
