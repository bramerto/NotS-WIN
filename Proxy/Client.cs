using Proxy.Messages;

namespace Proxy
{
    class Client
    {
        private IHttpMessage HttpMessage;

        public Client(IHttpMessage message)
        {
            HttpMessage = message;
        }

        public void HandleConnection()
        {
            
        }
    }
}
