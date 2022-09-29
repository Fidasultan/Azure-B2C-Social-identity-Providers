using System;

namespace SharpProg.Tutorials.AzureB2C.WebClient
{
    public class ProductApiSettings
    {
        public Uri BaseAddress { get; set; }
        public Uri Url { get; set; }
        
        public string ReadScope { get; set; }
    }
}