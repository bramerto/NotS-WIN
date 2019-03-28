using System;
using System.Collections;
using System.Text;

namespace Proxy.Messages
{
    class HttpRequest : IHttpMessage
    {
        private bool IsMethodLine = true;
        private bool ReachedBody = false;
        private bool IsJson = false;

        public string Message { get; set; }

        public string Method { get; private set; }
        public string URL { get; private set; }
        public string Version { get; private set; }
        public Hashtable Headers { get; private set; }

        public int Bodysize { get; private set; }
        public byte[] BodyData { get; private set; }
        public StringBuilder BodyString { get; private set; }
        public Hashtable BodyJson { get; private set; }

        public HttpRequest(string message)
        {
            Message = message;
            Headers = new Hashtable();
            Bodysize = 0;

            BodyJson = new Hashtable();
            BodyString = new StringBuilder();
            SetRequest();
        }

        protected void SetRequest()
        {
            string[] requestLines = Message.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach(string line in requestLines)
            {
                if (IsMethodLine)
                {
                    SetMethod(line);
                }
                else if (line.StartsWith("{"))
                {
                    ReachedBody = true;
                    IsJson = true;
                    
                    SetJsonBody(line);
                }
                else if (!ReachedBody)
                {
                    SetHeader(line);
                }
                else if (IsJson)
                {
                    SetJsonBody(line);
                }
                else
                {
                    SetBody(line);
                }
            }
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
            Headers.Add(headerLine[0], headerLine[1]);
        }

        private void SetBody(string line)
        {
            Console.WriteLine(line);
        }

        private void SetJsonBody(string line)
        {
            line = line.Trim(new char[] { '{', '}', ' ', '\t' });
            
            if (line.Length > 0)
            {
                string[] jsonData = line.Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries);
                for (int i=0; i<jsonData.Length;i++)
                {
                    jsonData[i] = jsonData[i].Trim(new char[] { ' ', '"' });
                }
               
                BodyJson.Add(jsonData[0], jsonData[1]);

            }
        }

        private void AppendBodyString(string line)
        {
            BodyString.Append(line);
        }

        public void ClearBody()
        {
            BodyString.Clear();
            Bodysize = 0;
            BodyJson = new Hashtable();
            BodyData = null;
        }

        public void ClearHeaders()
        {
            Headers = new Hashtable();
        }

        public void ClearHttpHeader()
        {
            Method = "";
            URL = "";
            Version = "";
        }

        public void ClearAll()
        {
            ClearBody();
            ClearHeaders();
            ClearHttpHeader();
            Message = "";
        }
    }
}
