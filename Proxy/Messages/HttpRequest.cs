using System;
using System.Collections;
using System.Text;

namespace Proxy.Messages
{
    class HttpRequest : IHttpMessage
    {
        private bool IsMethodLine = true;

        public string Message { get; set; }

        public string Method { get; private set; }
        public string URL { get; private set; }
        public string Version { get; private set; }
        public Hashtable Headers { get; private set; }

        public HttpRequest(string message)
        {
            Message = message;
            Headers = new Hashtable();
            SetRequest();
        }

        protected void SetRequest()
        {
            string[] requestLines = Message.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach(string line in requestLines)
            {
                if (IsMethodLine)
                {
                    SetMethod(line);
                }
                else
                {
                    SetHeader(line);
                }
            }
        }

        private void SetMethod(string line)
        {
            string[] methodLine = line.Split(' ');

            Method = methodLine[0];
            URL = methodLine[1];
            Version = methodLine[2];

            IsMethodLine = false;
        }

        private void SetHeader(string line)
        {
            string[] headerLine = line.Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries);
            Headers.Add(headerLine[0], headerLine[1]);
        }

        public void ClearHeaders()
        {
            Headers = new Hashtable();
        }

        public void ClearHttpHeader()
        {
            Method = "";
            URL = "";
            Version = "";
        }

        public void ClearAll()
        {
            ClearHeaders();
            ClearHttpHeader();
            Message = "";
        }
    }
}
