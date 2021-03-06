﻿using System;
using System.Collections.Concurrent;
using System.Text;

namespace ProxyServices.Messages
{
    public class HttpResponse : HttpMessage
    {
        private bool _isMethodLine;
        private bool _headerLines;
        public int StatusCode;
        public string Status;

        public string Body;

        public HttpResponse(byte[] messageInBytes)
        {
            _isMethodLine = true;
            _headerLines = true;
            Message = Encoding.ASCII.GetString(messageInBytes);
            Headers = new ConcurrentDictionary<string, string>();
            SetBody();
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
            try
            {
                var methodLine = line.Split(new[] { " " }, StringSplitOptions.None);

                Version = methodLine[0];
                StatusCode = int.Parse(methodLine[1]);
                Status = (methodLine.Length > 3) ? methodLine[2] + methodLine[3] : methodLine[2];
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
        }
        
        /// <summary>
        /// Sets all the header lines for the HttpResponse in a HashTable. Sets the body as well if there are no headers anymore.
        /// </summary>
        /// <param name="line"></param>
        private void SetHeader(string line)
        {
            var headerLine = line.Split(new [] { ": " }, StringSplitOptions.None);

            if (headerLine.Length > 1 && _headerLines)
            {
                Headers.TryAdd(headerLine[0], headerLine[1]);
            }
            else
            {
                _headerLines = false;
            }
        }

        /// <summary>
        /// Sets the body of the request.
        /// </summary>
        private void SetBody()
        {
            try
            {
                var requestBody = Message.Split(new[] { "\r\n\r\n" }, StringSplitOptions.None);
                if (requestBody.Length == 2) Body = requestBody[1];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// Sets the response back to a message
        /// </summary>
        /// <returns></returns>
        public string GetMessage()
        {
            var httpMessage = new StringBuilder();

            //Method line
            httpMessage.AppendLine($"{Version} {StatusCode} {Status}");

            httpMessage.Append(GetHeaders());

            httpMessage.AppendLine();

            //Body
            if (Body == null && Body == string.Empty) return httpMessage.ToString();

            httpMessage.Append(Body);

            return httpMessage.ToString();
        }
    }
}
