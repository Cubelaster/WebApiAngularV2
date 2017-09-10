using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace DAL.Models.HelperModels
{
    public class SortExpression<TEntity> where TEntity : class
    {
        public SortExpression(Expression<Func<TEntity, object>> sortBy, ListSortDirection sortDirection)
        {
            SortBy = sortBy;
            SortDirection = sortDirection;
        }

        public Expression<Func<TEntity, object>> SortBy { get; set; }
        public ListSortDirection SortDirection { get; set; }
    }

    public enum ListSortDirection
    {
        Ascending,
        Descending
    }
}