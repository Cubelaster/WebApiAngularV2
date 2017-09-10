using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using BL.Services.ServicesContracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BL.Controllers
{
    [Route("api/[controller]")]
  public class ProductController : Controller
  {
    IProductService _service;
    public ProductController(IProductService service)
    {
      _service = service;
    }

    //GET: api/values
    [HttpGet]
    public List<Product> Get()
    {
      return _service.GetAll();
    }
  }
}
