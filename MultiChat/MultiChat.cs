using System;
using System.Linq;
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
        
        /// <summary>
        /// Constructor of the MultiChat app
        /// </summary>
        public MultiChat()
        {
            localPort = 3000;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            InitializeComponent();

            // Enable to send a message with enter
            txtMessageToBeSend.KeyDown += (sender, args) => {
                if (args.KeyCode == Keys.Return)
                    btnSendMessage.PerformClick();
            };
        }

        // Delegate functions

        /// <summary>
        /// Adds a message on the UI thread if it needs to be invoked
        /// </summary>
        /// <param name="message"></param>
        public void AddMessage(string message)
        {
            // checks if chatbox can be invoked on this thread
            if (listChats.InvokeRequired)
                listChats.Invoke(new UpdateChatDelegate(UpdateChat), new object[] { "Incoming: " + message });
            else
                UpdateChat("Outgoing: " + message);
        }

        /// <summary>
        /// Updates the chatbox
        /// </summary>
        /// <param name="message"></param>
        private void UpdateChat(string message)
        {
            // Scroll down when list gets long
            int nItems = (int)(listChats.Height / listChats.ItemHeight);
            listChats.TopIndex = listChats.Items.Count - nItems;

            listChats.Items.Add(message);
        }

        /// <summary>
        /// Enables or disables the buttons on the UI thread based on state of the server or client
        /// </summary>
        /// <param name="server"></param>
        /// <param name="enable"></param>
        public void SetButtons(bool server, bool enable)
        {
            if (txtMessageToBeSend.InvokeRequired)
                listChats.Invoke(new SetButtonsDelegate(UpdateButtons), new object[] { server, enable });
            else
                UpdateButtons(server, enable);
        }

        /// <summary>
        /// Updates the buttons on the UI depending on the state of server or client
        /// </summary>
        /// <param name="server"></param>
        /// <param name="enable"></param>
        private void UpdateButtons(bool server, bool enable)
        {
            txtChatServerIP.ReadOnly = !enable;
            btnConnectWithServer.Enabled = enable;
            btnListen.Enabled = enable;

            // toggle message inputs when server is instantiated
            if (server)
            {
                txtMessageToBeSend.ReadOnly = !enable;
                btnSendMessage.Enabled = enable;
            }
        }

        // Methods

        /// <summary>
        /// Disconnects the application depending if the application serves as a server or client
        /// </summary>
        private void Disconnect()
        {
            // checks if server or client is instantiated and disposes the set server or client
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

        // Validation

        /// <summary>
        /// Validates the bufferinput
        /// </summary>
        /// <param name="bufferInput"></param>
        /// <returns></returns>
        private bool validateBufferSize()
        {
            string bufferInput = bufferSizeInput.Text;
            // checks if number put into bufferinput can be parsed to a number and number has to be above 1 and can not be above int maxvalue
            if (!String.IsNullOrEmpty(bufferInput) && int.TryParse(bufferInput, out int n) && n > 1 && n < int.MaxValue)
            {
                bufferSize = n;
                return true;
            }
            else
            {
                AddMessage("[validation]: Invalid buffersize");
                return false;
            }
        }

        /// <summary>
        /// Validates a string to be an IPv4 address
        /// </summary>
        /// <param name="ipString"></param>
        /// <returns></returns>
        public bool ValidateIPv4(string ipString)
        {
            // checkt of de ipstring niet leeg is
            if (String.IsNullOrWhiteSpace(ipString))
            {
                AddMessage("[validation]: IP address input is empty");
                return false;
            }

            string[] splitValues = ipString.Split('.');
            //checkt of de ipstring 4 punten in de string heeft
            if (splitValues.Length != 4)
            {
                AddMessage("[validation]: IP address input is too short");
                return false;
            }

            byte tempForParsing;

            bool success = splitValues.All(r => byte.TryParse(r, out tempForParsing));

            // looks if the ipaddress can be assessed to a number
            if (!success)
                AddMessage("[validation]: IP address input not correct");

            return success;
        }

        // Events

        /// <summary>
        /// Makes the current application serve as a server, and starts it based on buffer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListen_Click(object sender, EventArgs e)
        {
            //check of de buffersize input correct is
            if (validateBufferSize())
            {
                UpdateButtons(true, false);
                server = new Server(localPort, bufferSize, this);
                server.Start();
            }
        }

        /// <summary>
        /// Makes the current application serve as a client, and starts it based on buffer and IP input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnectWithServer_Click(object sender, EventArgs e)
        {
            string ipString = txtChatServerIP.Text;
            try
            {
                //check of de buffersize en ipstring input correct is 
                if (validateBufferSize() && ValidateIPv4(ipString))
                {
                    UpdateButtons(false, false);
                    TcpClient c = new TcpClient(ipString, localPort);
                    client = new Client(c, bufferSize, this);
                    client.Connect();
                }
            }
            catch (Exception ex)
            {
                AddMessage("[client]: Connection failed.");
                UpdateButtons(false, true);
            }
        }

        /// <summary>
        /// Sends a message to the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            string message = txtMessageToBeSend.Text;

            // looks if the client is instantiated and if the messagebox is empty
            if (client == null)
                AddMessage("[client]: There is no connection yet");
            else if
                (String.IsNullOrEmpty(message)) AddMessage("[validation]: Type a message first");
            else
            {
                // Disables the ability to send "!close" or "!disconnect
                if (!message.StartsWith("@"))
                {
                    client.Send(message);
                }

                txtMessageToBeSend.Clear();
                txtMessageToBeSend.Focus();
            }
        }

        /// <summary>
        /// Closes the form and disconnects the application from the networkstream and connection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MultiChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            Disconnect();
        }
    }
}
