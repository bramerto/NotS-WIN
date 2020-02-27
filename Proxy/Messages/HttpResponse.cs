using System;
using System.Collections;
using System.Text;

namespace ProxyServices.Messages
{
    internal class HttpResponse : HttpMessage
    {
        private bool _isMethodLine;
        public int StatusCode;
        public string Status;

        public string Body;
        
        public HttpResponse(string message)
        {
            _isMethodLine = true;
            Message = message;
            Headers = new Hashtable();
            SetResponse();
        }

        public void SetResponse()
        {
            var requestLines = Message.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in requestLines)
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

            Version = methodLine[0];
            StatusCode = int.Parse(methodLine[1]);
            Status = methodLine[2];
        }
        
        private void SetHeader(string line)
        {
            var headerLine = line.Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries);

            if (headerLine.Length > 1)
            {
                Headers.Add(headerLine[0], headerLine[1]);
            }
            else
            {
                Body = headerLine[0];
            }
        }

        public override string ToString()
        {
            var httpMessage = new StringBuilder();

            //Method line
            httpMessage.Append(Version + StatusCode + Status);

            foreach (var headerKey in Headers.Keys)
            {
                for (var i = 0; i < Headers.Count; i++)
                {
                    httpMessage.Append(headerKey + ":" + Headers[headerKey]);
                }
            }

            httpMessage.Append(Body);

            return httpMessage.ToString();
        }
    }
}
