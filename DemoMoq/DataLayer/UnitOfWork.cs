using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using DemoMoq.Library;

namespace DemoMoq.DataLayer
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private readonly IDbTransaction _dbTransaction;
        private readonly ObjectContext _objectContext;

        public UnitOfWork(IDataContext dataContext)
        {
            _dataContext = dataContext as DataContext ?? new DataContext();
            _objectContext = ((IObjectContextAdapter)_dataContext).ObjectContext;

            if (_objectContext.Connection.State == ConnectionState.Open) return;

            _objectContext.Connection.Open();
            _dbTransaction = _objectContext.Connection.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _dataContext.SaveChanges();
                _dbTransaction.Commit();
            }
            catch (Exception ex)
            {
                Utility.WriteLog(ex.ToString());
            }
        }

        public void Rollback()
        {
            _dbTransaction.Rollback();

            foreach (var dbEntityEntry in _dataContext.ChangeTracker.Entries())
            {
                switch (dbEntityEntry.State)
                {
                    case EntityState.Modified:
                        dbEntityEntry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        dbEntityEntry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        dbEntityEntry.State = EntityState.Unchanged;
                        break;
                }
            }
        }

        public void Dispose()
        {
            if (_objectContext.Connection.State == ConnectionState.Open)
            {
                _objectContext.Connection.Close();
            }
        }

    }
}
