using System;
using System.Collections.Concurrent;
using System.Text;

namespace ProxyServices.Messages
{
    public class HttpResponse : HttpMessage
    {
        private bool _isMethodLine;
        public int StatusCode;
        public string Status;

        public string Body;
        
        public HttpResponse(string message)
        {
            _isMethodLine = true;
            Message = message;
            Headers = new ConcurrentDictionary<string, string>();
            SetResponse();
        }

        /// <summary>
        /// Sets the full response from a HTTP string 
        /// </summary>
        private void SetResponse()
        {
            var requestLines = Message.Split(new [] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

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

        /// <summary>
        /// Sets the method line for the HttpResponse
        /// </summary>
        /// <param name="line"></param>
        private void SetMethod(string line)
        {
            var methodLine = line.Split(' ');

            Version = methodLine[0];
            StatusCode = int.Parse(methodLine[1]);
            Status = methodLine[2];
        }
        
        /// <summary>
        /// Sets all the header lines for the HttpResponse in a HashTable. Sets the body as well if there are no headers anymore.
        /// </summary>
        /// <param name="line"></param>
        private void SetHeader(string line)
        {
            var headerLine = line.Split(new [] { ": " }, StringSplitOptions.RemoveEmptyEntries);

            if (headerLine.Length > 1)
            {
                Headers.TryAdd(headerLine[0], headerLine[1]);
            }
            else
            {
                Body = headerLine[0];
            }
        }

        /// <summary>
        /// Sets the response back to a message
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public string GetMessage(bool filter)
        {
            var httpMessage = new StringBuilder();

            //Method line
            httpMessage.AppendLine(Version + " " + StatusCode + " " + Status);

            foreach (var header in Headers)
            {
                httpMessage.AppendLine(header.Key + ": " + header.Value);
            }

            //TODO: add ad filter to response here to replace pictures with placeholders
            if (filter)
            {
                if (Body != null)
                {
                    return string.Empty;
                }

                Console.WriteLine("AD FILTERING...");
            }

            if (Body != null)
            {
                httpMessage.AppendLine(Body);
            }


            return httpMessage.ToString();
        }
    }
}
