using ProxyServer.ViewModels;
using System;
using System.Windows;

namespace ProxyServer
{
    public partial class MainWindow : Window
    {
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
            Console.WriteLine("Server started");
        }

        private void StopServer(object sender, RoutedEventArgs e)
        {

        }

        private void SetBufferSize(object sender, RoutedEventArgs e)
        {

        }

        //Checkbox events
        private void EnableCache(object sender, RoutedEventArgs e)
        {

        }
    }
}
