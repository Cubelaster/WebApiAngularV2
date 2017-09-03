using DAL.Contracts.Abstracts;
using HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repository.RepositoryContracts.UOW
{
    public interface IGenericRepository<TEntity> where TEntity : DatabaseEntity
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string[] includePaths = null,
            int? page = null,
            int? pageSize = null,
            string includeProperties = "",
            params SortExpression<TEntity>[] sortExpressions);
        void Insert(TEntity entity);
        void Delete(int id);
        void SoftDelete(TEntity entityToDelete);
        void HardDelete(int id);
        void DeleteForever(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
    }
}
