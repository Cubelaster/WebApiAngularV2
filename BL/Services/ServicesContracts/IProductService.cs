using DAL.Models;
using System.Collections.Generic;

namespace BL.Services.ServicesContracts
{
    public interface IProductService
    {
        List<Product> GetAll();
    }
}
