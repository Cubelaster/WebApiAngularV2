using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApiAngularV2.Service;
using Database.Models;
using WebApiAngularV2.Service.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiAngularV2.Controllers
{
  [Route("api/[controller]")]
  public class ProductController : Controller
  {
    private IProductService _service;
    public ProductController(IProductService service)
    {
      _service = service;
    }

    //GET: api/values
   [HttpGet]
    public IEnumerable<Product> Get()
    {
      return _service.GetAll();
    }
  }
}
