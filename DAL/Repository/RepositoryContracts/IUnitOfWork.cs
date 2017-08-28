using DAL.Contracts.Abstracts;
using System;

namespace DAL.Repository.RepositoryContracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();

        GenericRepository<TEntity> GetRepository<TEntity>() where TEntity : DatabaseEntity;
    }
}
