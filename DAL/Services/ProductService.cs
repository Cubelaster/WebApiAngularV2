using DAL.Services.ServicesContracts;
using System.Collections.Generic;
using DAL.Models;
using DAL.Repository;
using System.Linq;
using DAL.Repository.RepositoryContracts;

namespace DAL.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _uow;
        private GenericRepository<Product> _repo;

        public ProductService(IUnitOfWork uow)
        {
            _uow = uow;
            _repo = _uow.GetRepository<Product>();
        }

        public List<Product> GetAll()
        {
            return _repo.Get().ToList();
        }
    }
}
