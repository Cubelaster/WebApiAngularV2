using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApiAngularV2.Controllers
{
  [Route("api/[controller]")]
  public class ValuesController : Controller
  {
    public ValuesController() { }

    // GET api/values
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return new string[] { "Hello", "World!" };
    }
  }
}
