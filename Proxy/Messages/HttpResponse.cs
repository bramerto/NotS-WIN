using System;
using System.Collections;

namespace ProxyServices.Messages
{
    internal class HttpResponse : HttpMessage
    {
        private bool IsMethodLine;
        public int StatusCode;
        public string Status;

        public string Body;
        
        public HttpResponse(string message)
        {
            IsMethodLine = true;
            Message = message;
            Headers = new Hashtable();
            SetResponse();
        }

        public void SetResponse()
        {
            var requestLines = Message.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in requestLines)
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
    }
}
