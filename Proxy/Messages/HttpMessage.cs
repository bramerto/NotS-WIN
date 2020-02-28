using System.Collections;

namespace ProxyServices.Messages
{
    public class HttpMessage
    {
        public string Message { get; set; }
        public Hashtable Headers { get; protected set; }
        public string Version { get; protected set; }

        public void ClearHeaders()
        {
            Headers.Clear();
        }

        public virtual void ClearHttpHeader()
        {
            Version = "";
        }
    }
}
