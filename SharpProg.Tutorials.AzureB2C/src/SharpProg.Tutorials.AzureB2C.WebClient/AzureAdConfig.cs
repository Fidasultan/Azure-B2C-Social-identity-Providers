
namespace SharpProg.Tutorials.AzureB2C.WebClient
{
    public class AzureAdConfig
    {
        public string ClientId { get; set; }
        public string TenantId { get; set; }
        public string ClientSecret { get; set; }
        public string Domain { get; set; }
        public string Instance { get; set; }
        public string SignupSigninPolicyId { get; set; }
        public string RedirectUrl { get; set; }
        public string Tenant { get; set; }
        public string SignedOutCallbackPath { get; set; }
    }
}
