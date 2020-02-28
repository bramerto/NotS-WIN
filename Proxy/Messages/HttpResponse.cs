using System;
using System.Collections;
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
            Headers = new Hashtable();
            SetResponse();
        }

        /// <summary>
        /// Sets the full response from a HTTP string 
        /// </summary>
        private void SetResponse()
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

        /// <summary>
        /// Sets the 
        /// </summary>
        /// <returns></returns>
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
