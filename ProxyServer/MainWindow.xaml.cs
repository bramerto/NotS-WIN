using System.Windows;
using ProxyServices;
using ProxyServices.Models;

namespace ProxyServer
{
    public partial class MainWindow : Window
    {
        int bufferSize;
        int port;
        int defaultPort;
        Server server;

        public MainWindow()
        {
            InitializeComponent();
            defaultPort = 8080;
            StopBtn.IsEnabled = false;
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

        private void Switch()
        {
            StartBtn.IsEnabled = (StartBtn.IsEnabled) ? false : true;
            StopBtn.IsEnabled = (StopBtn.IsEnabled) ? false : true;
            PortTxtB.IsEnabled = (PortTxtB.IsEnabled) ? false : true;
            BufferSizeTxtB.IsEnabled = (BufferSizeTxtB.IsEnabled) ? false : true;
            CacheCB.IsEnabled = (CacheCB.IsEnabled) ? false : true;
        }

        //Checkbox events
        private void EnableCache(object sender, RoutedEventArgs e)
        {

        }

        // Validation
        private int ValidateBufferSize(string bufferInput)
        {
            return (!string.IsNullOrEmpty(bufferInput) && int.TryParse(bufferInput, out int n) && n > 1 && n < int.MaxValue) ? n : 0;
        }

        private int ValidatePort(string portTxt)
        {
            bool succes = int.TryParse(portTxt, out int port);
            return (succes) ? port : defaultPort;
        }

        // Listview
        public void AddToList(ProxyLog pl)
        {
            listView.Items.Add(pl);
        }
    }
}
