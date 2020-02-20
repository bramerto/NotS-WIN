using System.Windows.Controls;
using ProxyServices;

namespace ProxyServer.ViewModels
{
    class ProxyViewModel
    {
        private Server server;
        private readonly int defaultPort;
        private int bufferSize;
        private int port;
        private readonly ListView _list;
        private ProxyUIEventArgs uiEventArgs;

        public ProxyViewModel(ListView list)
        {
            defaultPort = 8080;
            _list = list;
        }

        public void StartServer(ProxyUIEventArgs args)
        {
            uiEventArgs = args;
            bufferSize = ValidateBufferSize(uiEventArgs.buffer);
            port = ValidatePort(uiEventArgs.port);

            server = new Server(port, bufferSize, args);
            server.AddedToList += OnAddedToList;

            server.Start();
        }

        public void StopServer()
        {
            server.Dispose();
        }

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
            bool success = int.TryParse(portTxt, out int port);
            return (success) ? port : defaultPort;
        }

        public void OnAddedToList(object source, ProxyLogEventArgs e)
        {
            _list.Items.Add(e.ProxyLog);
        }
    }
}
