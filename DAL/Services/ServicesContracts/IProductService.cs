using DAL.Models;
using System.Collections.Generic;

namespace DAL.Services.ServicesContracts
{
    public interface IProductService
    {
        List<Product> GetAll();
    }
}
