using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SharpProg.Tutorials.AzureB2C.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductsController : ControllerBase
    {
        [Authorize(Policy = "ReadScope")]
        [HttpGet("get")]
        public IActionResult GetProducts()
        {
            return Ok(CatalogueDb.Products);
        }
    }
}
