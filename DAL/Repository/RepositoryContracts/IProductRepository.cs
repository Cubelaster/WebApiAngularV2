using DAL.Models;
using DAL.Repository.RepositoryContracts.UOW;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository.RepositoryContracts
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
