using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Controls;
using ProxyServices;
using ProxyServices.Models;

namespace ProxyServer.ViewModels
{
    internal class ProxyViewModel
    {
        private Server server;
        private readonly ListView _list;
        private readonly int defaultBufferSize;
        private readonly int defaultPort;
        private int bufferSize;
        private int port;

        private ObservableCollection<ProxyLog> Messages;

        public ProxyViewModel(ListView list)
        {
            defaultPort = 8080;
            defaultBufferSize = 1024;
            _list = list;
        }

        public void StartServer(ProxyUIEventArgs uiEventArgs)
        {
            bufferSize = ValidateBufferSize(uiEventArgs.buffer);
            port = ValidatePort(uiEventArgs.port);

            server = new Server(port, bufferSize, uiEventArgs);
            Messages = server.MessagesCollection;

            Messages.CollectionChanged += OnAddedToList;

            server.Start();
        }

        public void StopServer()
        {
            server.Dispose();
        }

        /// <summary>
        /// Validates a buffer size text and sets it to an int
        /// </summary>
        /// <param name="bufferInput"></param>
        /// <returns></returns>
        private int ValidateBufferSize(string bufferInput)
        {
            return (!string.IsNullOrEmpty(bufferInput) && int.TryParse(bufferInput, out var n) && n > 1 && n < int.MaxValue) ? 
                n :
                defaultBufferSize;
        }

        /// <summary>
        /// Validates a port text and sets it to an int
        /// </summary>
        /// <param name="portTxt"></param>
        /// <returns></returns>
        private int ValidatePort(string portTxt)
        {
            return (int.TryParse(portTxt, out var port)) ? 
                port :
                defaultPort;
        }

        public void OnAddedToList(object source, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            foreach (ProxyLog item in notifyCollectionChangedEventArgs.NewItems)
            {
                _list.Items.Add(item);
            }
        }
    }
}
