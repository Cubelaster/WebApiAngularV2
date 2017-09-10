using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using BL.Services.ServicesContracts;

namespace BL.Controllers
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
