using DAL.Contracts.Abstracts;
using DAL.Models;
using System;

namespace BL.Repository.UOW.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();

        //IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : DatabaseEntity;

        //IGenericRepository<Product> ProductRepository { get; }
    }
}
