using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DemoMoq.Library;

// ReSharper disable once CheckNamespace
namespace DemoMoq.DataLayer
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Gets all objects from database
        /// </summary>
        IEnumerable<T> All();

        /// <summary>
        /// Gets objects from database by filter.
        /// </summary>
        /// <param name="predicate">Specified a filter</param>
        IEnumerable<T> Filter(Expression<Func<T, bool>> predicate, params string[] includes);

        /// <summary>
        /// Gets paged list of objects from database by filter.
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="pagedView"></param>
        void Filter(Expression<Func<T, bool>> predicate, PagedView<T> pagedView);

        /// <summary>
        /// Find object by keys.
        /// </summary>
        /// <param name="keys">Specified the search keys.</param>
        T Find(params object[] keys);

        /// <summary>
        /// Find object by specified expression.
        /// </summary>
        /// <param name="predicate"></param>
        T Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        T Insert(T t);

        /// <summary>
        /// Update object changes and save to database.
        /// </summary>
        /// <param name="t">Specified the object to save.</param>
        void Update(T t);

        /// <summary>
        /// Delete the object from database.
        /// </summary>
        /// <param name="t">Specified a existing object to delete.</param>        
        void Delete(T t);
    }
}
