using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DAL.Services.ServicesContracts;
using DAL.Models;

namespace WebApiAngularV2.Controllers
{
  [Route("api/[controller]")]
  public class ValuesController : Controller
  {
    IProductService _service;
    public ValuesController(IProductService service)
    {
      _service = service;
    }

    // GET api/values
    [HttpGet]
    public List<Product> Get()
    {
      return _service.GetAll();
    }
  }
}
