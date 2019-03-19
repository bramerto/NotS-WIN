using System;
using System.Collections;
using System.Text;

namespace Proxy.Messages
{
    class HttpRequest : IHttpMessage
    {
        private bool IsMethodLine = true;
        private bool ReachedBody = false;

        public string Message;

        public string Method { get; private set; }
        public string URL { get; private set; }
        public string Version { get; private set; }
        public Hashtable Headers { get; private set; }

        public int Bodysize { get; private set; }
        public byte[] BodyData { get; set; }
        public StringBuilder BodyString { get; set; }

        public HttpRequest(string message)
        {
            Message = message;
            Headers = new Hashtable();
            BodyString = new StringBuilder();
        }

        public void SetRequest()
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

            SetData();
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

            if (headerLine[1] == null)
            {
                ReachedBody = true;
                AppendBody(headerLine[0]);
            }
            else
            {
                if (!ReachedBody) Headers.Add(headerLine[0], headerLine[1]);
            }
        }

        private void SetData()
        {

        }

        private void AppendBody(string line)
        {
            BodyString.Append(line);
        }

        public void ClearBody()
        {
            BodyString.Clear();
        }
    }
}
