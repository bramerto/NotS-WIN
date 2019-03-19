using System.Collections;

namespace Proxy.Messages
{
    class HttpResponse : IHttpMessage
    {
        public string Message;

        public int Status;
        public string Version;
        public Hashtable Headers;
        public int BodySize;
        public string BodyData;

        public enum State
        {
            OK                    = 200,
            BAD_REQUEST           = 400,
            NOT_FOUND             = 404,
            INTERNAL_SERVER_ERROR = 500
        }
    }
}
