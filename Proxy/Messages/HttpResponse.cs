using System.Collections;

namespace Proxy.Messages
{
    class HttpResponse : HttpMessage
    {
        public enum Status
        {
            OK                    = 200,
            BAD_REQUEST           = 400,
            NOT_FOUND             = 404,
            INTERNAL_SERVER_ERROR = 500
        }
    }
}
