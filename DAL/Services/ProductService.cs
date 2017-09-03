using DAL.Services.ServicesContracts;
using System.Collections.Generic;
using DAL.Models;
using System.Linq;
using DAL.Repository.RepositoryContracts.UOW;

namespace DAL.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _uow;
        private IGenericRepository<Product> _repo;

        public ProductService(IUnitOfWork uow)
        {
            _uow = uow;
            _repo = _uow.ProductRepository;
        }

        public List<Product> GetAll()
        {
            return _repo.Get().ToList();
        }
    }
}
