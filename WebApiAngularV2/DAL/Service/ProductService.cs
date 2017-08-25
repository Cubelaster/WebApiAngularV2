using DAL.Models;
using System.Collections.Generic;
using WebApiAngularV2.Repository;
using WebApiAngularV2.Repository.Contracts;
using WebApiAngularV2.Service.Contracts;

namespace WebApiAngularV2.Service
{
  public class ProductService : IProductService
  {
    IProductRepository _repo;
    public ProductService(IProductRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Product> GetAll()
    {
      return _repo.GetAll();
    }
  }
}
