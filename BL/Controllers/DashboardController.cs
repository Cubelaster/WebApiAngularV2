using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Controllers
{
    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        public DashboardController() { }

        // GET api/dashboard/home
        [HttpGet("home")]
        public IActionResult GetHome()
        {
            return new OkObjectResult(new { Message = "This is secure data!" });
        }
    }
}
