using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;
using Newtonsoft.Json;
using SharpProg.Tutorials.AzureB2C.Core;

namespace SharpProg.Tutorials.AzureB2C.WebClient.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly ProductApiSettings _productApiSettings;
        private readonly HttpClient _productClient;
        private readonly ITokenAcquisition _tokenAcquisition;
        private readonly string _productReadScope;

        public ProductsController(IOptionsMonitor<ProductApiSettings> optionsMonitor, IHttpClientFactory httpClientFactory, ITokenAcquisition tokenAcquisition )
        {
            _productApiSettings = optionsMonitor.CurrentValue;
            _productClient = httpClientFactory.CreateClient(B2CConstants.ProductClientName);
            _tokenAcquisition = tokenAcquisition;
            _productReadScope = _productApiSettings.ReadScope;
            
        }
        
        [AuthorizeForScopes(ScopeKeySection = "ProductApi:ReadScope")]
        public async Task<IActionResult> Index()
        {
            await PrepareClient();

            var productRsponse = await _productClient.GetAsync(_productApiSettings.Url);

            if(!productRsponse.IsSuccessStatusCode)
            {
                throw new Exception(productRsponse.ReasonPhrase);
            }

            var content = await productRsponse.Content.ReadAsStringAsync();

            var products = JsonConvert.DeserializeObject<List<Product>>(content);
            
            return View(products);
        }

        private async Task PrepareClient()
        {
            var accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(new[] { _productReadScope });

            Debug.WriteLine($"access token-{accessToken}");

            _productClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }
    }
}
