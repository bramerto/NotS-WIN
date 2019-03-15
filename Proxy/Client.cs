using Proxy.Messages;

namespace Proxy
{
    class Client
    {
        private IHttpMessage _socket;

        public Client(IHttpMessage message)
        {
            _socket = message;
        }

        public void HandleConnection()
        {
            
        }
    }
}
