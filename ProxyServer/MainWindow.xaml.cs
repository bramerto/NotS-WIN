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

        private void FormSizeChanged(object sender, SizeChangedEventArgs e)
        {
            LayoutGrid.Width = e.NewSize.Width;
            LayoutGrid.Height = e.NewSize.Height;
        }

        private void StartServer(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Server started");
        }
    }
}
