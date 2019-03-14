using System;
using System.Windows;
using Proxy;

namespace ProxyServer
{
    public partial class MainWindow : Window
    {
        int bufferSize;
        Server server;

        public MainWindow()
        {
            InitializeComponent();
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
            int port = ValidatePort(PortTxtB.Text);
            server = new Server(bufferSize, port);

            server.Start();
        }

        private void StopServer(object sender, RoutedEventArgs e)
        {
            server.Dispose();
        }

        private void SetBufferSize(object sender, RoutedEventArgs e)
        {

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

        // TODO: implement
        private int ValidatePort(string portInput)
        {
            return 8080;
        }
    }
}
