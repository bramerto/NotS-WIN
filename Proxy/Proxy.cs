using System;
using System.Collections.ObjectModel;
using ProxyServices.Models;

namespace ProxyServices
{
    public class Proxy
    {
        public ObservableCollection<ProxyLog> MessagesCollection;

        public Proxy()
        {
            MessagesCollection = new ObservableCollection<ProxyLog>();
        }

        /// <summary>
        /// Adds an message to the list view.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        protected void AddUiMessage(string message, string type)
        {
            MessagesCollection.Add(new ProxyLog() { Message = message, Source = "Server", Type = type });
            Console.WriteLine(message);
        }
    }
}
