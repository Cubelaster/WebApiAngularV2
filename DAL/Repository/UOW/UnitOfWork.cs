using DAL.Repository.RepositoryContracts.UOW;
using System;
using DAL.Models;

namespace DAL.Repository.UOW
{
    public partial class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private readonly HeroContext _context;

        #region Repositories
        private IGenericRepository<Product> _productRepository;
        #endregion Repositories

        #region Repositories Getters
        public IGenericRepository<Product> ProductRepository
        {
            get
            {
                if (this._productRepository == null)
                {
                    this._productRepository = new GenericRepository<Product>(_context);
                }
                return _productRepository;
            }
        }
        #endregion Repositories Getters

        public UnitOfWork(HeroContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        //public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : DatabaseEntity
        //{
        //    return new GenericRepository<TEntity>(_context);
        //}
    }
}
