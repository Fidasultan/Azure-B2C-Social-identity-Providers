using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SharpProg.Tutorials.AzureB2C.Api.Controllers
{
    [ApiController]
    [Route("")]
    [AllowAnonymous]
    public class HomeController : ControllerBase
    {
        

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "Products Web Api is running! B2C Api" });

        }
    }
}
