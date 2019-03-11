﻿using ProxyServer.ViewModels;
using System;
using System.Windows;

namespace ProxyServer
{
    public partial class MainWindow : Window
    {
        ProxyViewModel _ViewModel = new ProxyViewModel();
        public MainWindow()
        {
            InitializeComponent();
            base.DataContext = _ViewModel;
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

        private void EnableImageFilter(object sender, RoutedEventArgs e)
        {

        }

        private void EnableAdFilter(object sender, RoutedEventArgs e)
        {

        }

        private void EnablePrivacyFilter(object sender, RoutedEventArgs e)
        {

        }

        private void EnableScriptFilter(object sender, RoutedEventArgs e)
        {

        }
    }
}
