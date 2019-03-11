using Proxy.Messages;
using System.ComponentModel;

namespace ProxyServer.ViewModels
{
    class ProxyViewModel : INotifyPropertyChanged
    {
        public ProxyViewModel()
        {
            Log = new ProxyLog();
        }

        public ProxyLog Log { get; set; }
        public string Message
        {
            get
            {
                return (Log.HttpMessage == null) ? Log.Message : Log.HttpMessage.ToString();
            }

            set
            {
                Log.Message = value;
                RaisePropertyChanged("Message");
            }
        }

        public string LogType
        {
            get
            {
                return Log.Type;
            }
            set
            {
                Log.Type = value;
                RaisePropertyChanged("LogType");
            }
        }

        public string Source
        {
            get
            {
                return Log.Source;
            }

            set
            {
                Log.Source = value;
                RaisePropertyChanged("Source");
            }
        }

        public IHttpMessage HttpMessage
        {
            get
            {
                return Log.HttpMessage;
            }
            set
            {
                Log.HttpMessage = value;
                RaisePropertyChanged("HttpMessage");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
