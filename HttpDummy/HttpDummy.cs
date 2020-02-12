using System;
using System.IO;
using System.Net;
using System.Text;

namespace HttpDummy
{
    class HttpDummy
    {
        static void Main(string[] args)
        {
            HttpListener listener;
            listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:4000/dummy/");
            listener.Start();
            Console.WriteLine("Listening...");

            while (true)
            {
                try
                {
                    var context = listener.GetContext();
                    string msg = "<h1>Hello World!</h1>";
                    context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(msg);
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    using (Stream stream = context.Response.OutputStream)
                    {
                        using (StreamWriter writer = new StreamWriter(stream))
                        {
                            writer.Write(msg);
                        }
                    }

                    Console.WriteLine("Message sent (HTTP 200 OK)");
                }
                catch (WebException ex)
                {
                    Console.WriteLine("Something went wrong (HTTP 500 Internal Server Error)");
                    Console.WriteLine(ex.Status);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something went wrong: " + ex);
                }
            }
        }
    }
}
