using System;
using System.Collections.Concurrent;

namespace ProxyServices.Messages
{
    public class HttpRequest : HttpMessage
    {
        private bool _isMethodLine;

        public string Url { get; protected set; }

        public HttpRequest(string message)
        {
            _isMethodLine = true;
            Message = message;
            Headers = new ConcurrentDictionary<string, string>();
            SetRequest();
        }

        /// <summary>
        /// Sets the full request from the message that is set.
        /// </summary>
        private void SetRequest()
        {
            var requestLines = Message.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

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

        /// <summary>
        /// Sets the method line from a single line
        /// </summary>
        /// <param name="line"></param>
        private void SetMethod(string line)
        {
            var methodLine = line.Split(new [] {" "}, StringSplitOptions.None);
            Url = methodLine[1];
        }

        /// <summary>
        /// Sets a header from a single line
        /// </summary>
        /// <param name="line"></param>
        private void SetHeader(string line)
        {
            var headerLine = line.Split(new [] { ": " }, StringSplitOptions.RemoveEmptyEntries);
            if (headerLine.Length > 1) Headers.TryAdd(headerLine[0], headerLine[1]);
        }
    }
}
