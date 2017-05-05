using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using DemoMoq.Library;

namespace DemoMoq.DataLayer
{
    class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _dataContext;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        private DbSet<T> DbSet()
        {
            return _dataContext.Set<T>();
        }

        public IEnumerable<T> All()
        {
            return DbSet().AsEnumerable();
        }

        public IQueryable<T> Table()
        {
            return DbSet();
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            var dbSet = DbSet().Where(predicate).AsQueryable();

            if (includes == null || !includes.Any()) return dbSet;

            return includes.Aggregate(dbSet, (current, include) => current.Include(include));
        }

        public void Filter(Expression<Func<T, bool>> predicate, PagedView<T> pagedView)
        {
            var sortExpression = $"{ pagedView.Sort ?? "Id"} {pagedView.SortDir ?? "ASC"}";

            var dbSet = DbSet().Where(predicate).OrderBy(sortExpression).AsQueryable();

            pagedView.TotalRecords = dbSet.Count();

            pagedView.RecordIndex = ((pagedView.Page ?? 1) - 1) * pagedView.PageSize;

            pagedView.ResultSet = dbSet.Skip(pagedView.RecordIndex).Take(pagedView.PageSize);
        }


        public T Find(params object[] keys)
        {
            return DbSet().Find(keys);
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet().Where(predicate).FirstOrDefault();
        }

        public T Insert(T entity)
        {
            DbSet().Add(entity);

            return entity;
        }

        public void Update(T entity)
        {
            var primaryKey = 0;

            var prop = entity.GetType().GetProperty("Id");

            if (prop != null) { primaryKey = (int)prop.GetValue(entity, null); }

            var currentEntry = DbSet().Find(primaryKey);

            if (currentEntry != null)
            {
                var attachedEntry = _dataContext.Entry(currentEntry);

                attachedEntry.CurrentValues.SetValues(entity);
            }
            else
            {
                DbSet().Attach(entity);

                _dataContext.Entry(entity).State = EntityState.Modified;
            }
        }

        public void Delete(T entity)
        {
            DbSet().Remove(entity);
        }
    }
}
