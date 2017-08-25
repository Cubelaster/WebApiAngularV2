using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using DAL;

namespace WebApiAngularV2.Controllers
{
  [Route("api/[controller]")]
  public class ValuesController : Controller
  {
    HeroContext _context;

    public ValuesController(HeroContext context)
    {
      _context = context;
    }

    // GET api/values
    [HttpGet]
    public IEnumerable<string> Get()
    {
      var bla = _context.Hero.ToArray();
      return new string[] { "Hello", "World!" };
    }
  }
}
