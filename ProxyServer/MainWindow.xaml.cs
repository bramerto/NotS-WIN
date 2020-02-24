using System.Windows;
using ProxyServer.ViewModels;
using ProxyServices;

namespace ProxyServer
{
    public partial class MainWindow : Window
    {
        private readonly ProxyViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new ProxyViewModel(ListView);
            DataContext = _viewModel;
        }

        /// <summary>
        /// Reshapes the form size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSizeChanged(object sender, SizeChangedEventArgs e)
        {
            LayoutGrid.Width = e.NewSize.Width;
            LayoutGrid.Height = e.NewSize.Height;
        }

        /// <summary>
        /// Starts the proxy from "Start" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartProxy(object sender, RoutedEventArgs e)
        {
            var args = new ProxyUIEventArgs()
            {
                buffer = BufferSizeTxtB.Text,
                port = PortTxtB.Text,
                advertisementFilterEnabled = AdvertiseFilterCb.IsChecked != null && AdvertiseFilterCb.IsChecked.Value,
                privacyFilterEnabled = PrivacyFilterCb.IsChecked != null && PrivacyFilterCb.IsChecked.Value,
                cacheEnabled = CacheCb.IsChecked != null && CacheCb.IsChecked.Value
            };
            _viewModel.StartServer(args);
            Switch();
        }

        /// <summary>
        /// Stops the proxy from "Stop" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopProxy(object sender, RoutedEventArgs e)
        {
            _viewModel.StopServer();
            Switch();
        }

        /// <summary>
        /// Switches to disable or enable UI elements if the proxy started or stopped.
        /// </summary>
        private void Switch()
        {
            StartBtn.IsEnabled = (!StartBtn.IsEnabled);
            StopBtn.IsEnabled = (!StopBtn.IsEnabled);

            PortTxtB.IsEnabled = (!PortTxtB.IsEnabled);
            BufferSizeTxtB.IsEnabled = (!BufferSizeTxtB.IsEnabled);

            CacheCb.IsEnabled = (!CacheCb.IsEnabled);
            AdvertiseFilterCb.IsEnabled = (!AdvertiseFilterCb.IsEnabled);
            PrivacyFilterCb.IsEnabled = (!PrivacyFilterCb.IsEnabled);
        }
    }
}
