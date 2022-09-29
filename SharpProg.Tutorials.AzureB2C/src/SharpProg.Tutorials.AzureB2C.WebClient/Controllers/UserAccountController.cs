using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SharpProg.Tutorials.AzureB2C.WebClient.Controllers
{
    public class UserAccountController : Controller
    {
        public IActionResult Logout()
        {   
            return View();
        }
    }
}
