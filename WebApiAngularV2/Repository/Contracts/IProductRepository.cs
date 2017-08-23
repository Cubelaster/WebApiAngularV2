using Database.Models;
using System.Collections.Generic;

namespace WebApiAngularV2.Repository.Contracts
{
  public interface IProductRepository
  {
    IEnumerable<Product> GetAll();
  }
}
