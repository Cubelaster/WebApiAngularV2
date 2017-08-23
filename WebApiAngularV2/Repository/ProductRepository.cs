using Database;
using Database.Models;
using System.Collections.Generic;
using System.Linq;
using WebApiAngularV2.Repository.Contracts;

namespace WebApiAngularV2.Repository
{
  public class ProductRepository : IProductRepository
  {
    private HeroContext _context;
    public ProductRepository(HeroContext context)
    {
      _context = context;
    }

    public IEnumerable<Product> GetAll()
    {
      return _context.Product.ToList();
    }
  }
}
