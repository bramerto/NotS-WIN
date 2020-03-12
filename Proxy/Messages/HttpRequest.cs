using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace ProxyServices.Messages
{
    public class HttpRequest : HttpMessage
    {
        private bool _isMethodLine; 
        public string Url { get; protected set; }
        public string Method { get; private set; }

        public bool AcceptIsVideoOrImage =>
            (Headers["Accept"].Contains("video") || Headers["Accept"].Contains("image")) &&
            !Headers["Accept"].Contains("html");

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
            try
            {
                var methodLine = line.Split(new[] { " " }, StringSplitOptions.None);
                Method = methodLine[0];
                Url = methodLine[1];
                Version = methodLine[2];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
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

        /// <summary>
        /// Sets the response back to a message
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public string GetMessage()
        {
            var httpMessage = new StringBuilder();

            //Method line
            httpMessage.AppendLine($"{Method} {Url} {Version}");

            httpMessage.Append(GetHeaders());

            httpMessage.AppendLine();

            return httpMessage.ToString();
        }
    }
}
