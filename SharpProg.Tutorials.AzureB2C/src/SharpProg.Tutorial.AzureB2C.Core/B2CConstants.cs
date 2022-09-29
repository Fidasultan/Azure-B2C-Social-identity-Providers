
using System.Collections.Generic;

namespace SharpProg.Tutorials.AzureB2C.Core
{
    public class B2CConstants
    {
        public const string AzureAdConfigSection = "AzureAdB2C";
        public const string ApiConfigSection = "ProductApi";
        public readonly static List<string> Scopes = new List<string> { "products.read", "products.write" };
        public const string Bearer = nameof(Bearer);
        public const string ProductClientName = "ProductClient";
    }
}
