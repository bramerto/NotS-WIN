using System;
using System.Collections.ObjectModel;
using ProxyServices.Models;

namespace ProxyServices
{
    public class Proxy
    {
        public ObservableCollection<ProxyLog> MessagesCollection;
        private readonly int maxMessageLength;

        public Proxy()
        {
            MessagesCollection = new ObservableCollection<ProxyLog>();
            maxMessageLength = 60;
        }

        /// <summary>
        /// Adds an message to the list view.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        protected void AddUiMessage(string message, string type)
        {
            MessagesCollection.Add(new ProxyLog
            {
                Message = message.Substring(0, Math.Min(message.Length, maxMessageLength)).TrimEnd(),
                Source = "Server",
                Type = type
            });
            Console.WriteLine(message);
        }
    }
}
