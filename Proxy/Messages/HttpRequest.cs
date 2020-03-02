using System;
using System.Collections;

namespace ProxyServices.Messages
{
    public class HttpRequest : HttpMessage
    {
        private bool _isMethodLine;

        public string Method { get; private set; }
        public string Url { get; protected set; }
        public int Port { get; set; }

        public HttpRequest(string message)
        {
            _isMethodLine = true;
            Message = message;
            Headers = new Hashtable();
            SetRequest();
        }

        private void SetRequest()
        {
            var requestLines = Message.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach(var line in requestLines)
            {
                if (_isMethodLine)
                {
                    SetMethod(line);
                    _isMethodLine = false;
                }
                else
                {
                    SetHeader(line);
                }
            }
        }

        private void SetMethod(string line)
        {
            var methodLine = line.Split(' ');

            Method = methodLine[0];
            Url = methodLine[1];
            Version = methodLine[2];
        }

        private void SetHeader(string line)
        {
            var headerLine = line.Split(new [] { ": " }, StringSplitOptions.RemoveEmptyEntries);
            if (headerLine.Length > 1) Headers.Add(headerLine[0], headerLine[1]);
        }

        public override void ClearHttpHeader()
        {
            base.ClearHttpHeader();
            Method = "";
            Url = "";
        }

        public string ParseUrl()
        {
            var urlSplit = Url.Split(':');
            Port = int.Parse(urlSplit[2].Split('/')[0]);
            return urlSplit[1].TrimStart('/');
        }
    }
}
