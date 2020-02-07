using System;
using System.Collections;

namespace ProxyServices.Messages
{
    class HttpRequest : HttpMessage
    {
        private bool IsMethodLine;

        public string Method { get; private set; }
        public string URL { get; protected set; }

        public HttpRequest(string message)
        {
            IsMethodLine = true;
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
                    IsMethodLine = false;
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
        }

        private void SetHeader(string line)
        {
            string[] headerLine = line.Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries);
            if (headerLine.Length > 0) Headers.Add(headerLine[0], headerLine[1]);
        }

        public override void ClearHttpHeader()
        {
            base.ClearHttpHeader();
            Method = "";
            URL = "";
        }
    }
}
