using Database.Models;
using System.Collections.Generic;

namespace WebApiAngularV2.Service.Contracts
{
  public interface IProductService
  {
    IEnumerable<Product> GetAll();
  }
}
