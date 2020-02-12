using System.Windows;
using ProxyServices;

namespace ProxyServer
{
    public partial class MainWindow : Window
    {
        int bufferSize;
        int port;
        readonly int defaultPort;
        Server server;

        public MainWindow()
        {
            InitializeComponent();
            defaultPort = 8080;
        }

        //Form events
        private void FormSizeChanged(object sender, SizeChangedEventArgs e)
        {
            LayoutGrid.Width = e.NewSize.Width;
            LayoutGrid.Height = e.NewSize.Height;
        }

        //Button events
        private void StartServer(object sender, RoutedEventArgs e)
        {
            bufferSize = ValidateBufferSize(BufferSizeTxtB.Text);
            port = ValidatePort(PortTxtB.Text);
            
            server = new Server(port, bufferSize);

            server.Start();
            Switch();
        }

        private void StopServer(object sender, RoutedEventArgs e)
        {
            server.Dispose();
            Switch();
        }

        // Validation

        /// <summary>
        /// Validates a buffersize text and sets it to an int
        /// </summary>
        /// <param name="bufferInput"></param>
        /// <returns></returns>
        private int ValidateBufferSize(string bufferInput)
        {
            return (!string.IsNullOrEmpty(bufferInput) && int.TryParse(bufferInput, out int n) && n > 1 && n < int.MaxValue) ? n : 0;
        }

        /// <summary>
        /// Validates a port text and sets it to an int
        /// </summary>
        /// <param name="portTxt"></param>
        /// <returns></returns>
        private int ValidatePort(string portTxt)
        {
            bool succes = int.TryParse(portTxt, out int port);
            return (succes) ? port : defaultPort;
        }

        // Other 

        /// <summary>
        /// Switches to disable or enable UI elements if the proxy started or stopped.
        /// </summary>
        private void Switch()
        {
            StartBtn.IsEnabled = (StartBtn.IsEnabled) ? false : true;
            StopBtn.IsEnabled = (StopBtn.IsEnabled) ? false : true;
            PortTxtB.IsEnabled = (PortTxtB.IsEnabled) ? false : true;
            BufferSizeTxtB.IsEnabled = (BufferSizeTxtB.IsEnabled) ? false : true;
            CacheCB.IsEnabled = (CacheCB.IsEnabled) ? false : true;
            AdvertiseFilterCB.IsEnabled = (AdvertiseFilterCB.IsEnabled) ? false : true;
            privacyFilterCB.IsEnabled = (privacyFilterCB.IsEnabled) ? false : true;
        }
    }
}
