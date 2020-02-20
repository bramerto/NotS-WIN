namespace ProxyServices
{
    public class ProxyUIEventArgs
    {
        public string buffer { get; set; }
        public string port { get; set; }
        
        public bool cacheEnabled { get; set; }
        public bool privacyFilterEnabled { get; set; }
        public bool advertisementFilterEnabled { get; set; }
    }
}
