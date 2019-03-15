using System;

namespace Proxy.Messages
{
    class HttpRequest : IHttpMessage
    {
        string _message;
        string method;
        string path;
        string body;

        public HttpRequest(string message)
        {
            _message = message;
        }

        public void SetRequest()
        {
            string[] requestLines = _message.Split('\n');

            foreach(string line in requestLines)
            {
                Console.WriteLine(line);
            }
        }

        internal void SetHeader()
        {
            
        }

        internal void SetBody()
        {

        }
    }
}
