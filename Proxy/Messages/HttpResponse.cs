using System;
using System.Collections;

namespace Proxy.Messages
{
    class HttpResponse : HttpMessage
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
            string[] requestLines = Message.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in requestLines)
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

            Version = methodLine[0];
            StatusCode = Int32.Parse(methodLine[1]);
            Status = methodLine[2];
        }
        
        private void SetHeader(string line)
        {
            string[] headerLine = line.Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries);

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
