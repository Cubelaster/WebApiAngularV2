using DAL.Contracts.Abstracts;
using DAL.Contracts.Enumerations;
using HelperModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repository
{
    public class GenericRepository<TEntity> where TEntity : DatabaseEntity
    {
        internal HeroContext _context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(HeroContext context)
        {
            _context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string[] includePaths = null,
            int? page = null,
            int? pageSize = null,
            string includeProperties = "",
            params SortExpression<TEntity>[] sortExpressions
            )
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            SoftDelete(entityToDelete);
        }

        public virtual void SoftDelete(TEntity entityToDelete)
        {
            entityToDelete.Status = DatabaseEntityStatusEnum.Deleted;
            dbSet.Attach(entityToDelete);
            _context.Entry(entityToDelete).State = EntityState.Modified;
        }

        public virtual void HardDelete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            DeleteForever(entityToDelete);
        }

        public virtual void DeleteForever(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

    }
}