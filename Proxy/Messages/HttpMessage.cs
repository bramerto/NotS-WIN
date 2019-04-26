using System.Collections;

namespace Proxy.Messages
{
    public class HttpMessage
    {
        public string Message { get; set; }
        public Hashtable Headers { get; protected set; }
        public string URL { get; protected set; }
        public string Version { get; protected set; }

        public void ClearHeaders()
        {
            Headers.Clear();
        }

        public virtual void ClearHttpHeader()
        {
            URL = "";
            Version = "";
        }

        public void Clear()
        {
            ClearHeaders();
            ClearHttpHeader();
            Message = "";
        }
    }
}
