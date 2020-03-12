using System.Collections.Concurrent;
using System.Text;

namespace ProxyServices.Messages
{
    public class HttpMessage
    {
        public string Message { get; set; }
        public ConcurrentDictionary<string, string> Headers { get; protected set; }
        public string Version { get; protected set; }

        public string GetHeaders()
        {
            var stringBuilder = new StringBuilder();
            foreach (var header in Headers)
            {
                stringBuilder.AppendLine(header.Key + ":" + header.Value);
            }

            return stringBuilder.ToString();
        }
    }
}
