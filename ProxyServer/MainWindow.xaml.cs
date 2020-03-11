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

        private void FormSizeChanged(object sender, SizeChangedEventArgs e)
        {
            LayoutGrid.Width = e.NewSize.Width;
            LayoutGrid.Height = e.NewSize.Height;
        }

        private void StartProxy(object sender, RoutedEventArgs e)
        {
            var args = new ProxyUiEventArgs()
            {
                Buffer = BufferSizeTxtB.Text,
                Port = PortTxtB.Text,
                AdvertisementFilterEnabled = AdvertiseFilterCb.IsChecked != null && AdvertiseFilterCb.IsChecked.Value,
                PrivacyFilterEnabled = PrivacyFilterCb.IsChecked != null && PrivacyFilterCb.IsChecked.Value,
                CacheEnabled = CacheCb.IsChecked != null && CacheCb.IsChecked.Value
            };
            _viewModel.StartServer(args);
            Switch();
        }

        private void StopProxy(object sender, RoutedEventArgs e)
        {
            _viewModel.StopServer();
            Switch();
        }

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
