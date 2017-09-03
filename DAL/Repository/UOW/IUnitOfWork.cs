using DAL.Contracts.Abstracts;
using DAL.Models;
using System;

namespace DAL.Repository.RepositoryContracts.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();

        //IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : DatabaseEntity;

        IGenericRepository<Product> ProductRepository { get; }
    }
}
