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

        public ProxyViewModel(ListView list)
        {
            defaultPort = 8080;
            defaultBufferSize = 1024;
            _list = list;
        }

        /// <summary>
        /// Starts the server
        /// </summary>
        /// <param name="uiEventArgs"></param>
        public void StartServer(ProxyUIEventArgs uiEventArgs)
        {
            bufferSize = ValidateBufferSize(uiEventArgs.buffer);
            port = ValidatePort(uiEventArgs.port);

            server = new Server(port, bufferSize, uiEventArgs);

            server.MessagesCollection.CollectionChanged += OnAddedToList;
            server.Client.MessagesCollection.CollectionChanged += OnAddedToList;

            server.Start();
        }

        /// <summary>
        /// Stops the server
        /// </summary>
        public void StopServer()
        {
            server.Stop();
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

        /// <summary>
        /// Adds a ProxyLog item to the list view
        /// </summary>
        /// <param name="source"></param>
        /// <param name="notifyCollectionChangedEventArgs"></param>
        public void OnAddedToList(object source, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            foreach (ProxyLog item in notifyCollectionChangedEventArgs.NewItems)
            {
                _list.Items.Add(item);
            }
        }
    }
}
