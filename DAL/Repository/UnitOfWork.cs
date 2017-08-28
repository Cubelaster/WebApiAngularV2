using DAL.Contracts.Abstracts;
using DAL.Repository.RepositoryContracts;
using System;

namespace DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private HeroContext _context;

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

        public GenericRepository<TEntity> GetRepository<TEntity>() where TEntity : DatabaseEntity
        {
            return new GenericRepository<TEntity>(_context);
        }
    }
}
