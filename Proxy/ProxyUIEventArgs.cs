namespace ProxyServices
{
    public class ProxyUiEventArgs
    {
        public string Buffer { get; set; }
        public string Port { get; set; }
        
        public bool CacheEnabled { get; set; }
        public bool PrivacyFilterEnabled { get; set; }
        public bool AdvertisementFilterEnabled { get; set; }
    }
}
