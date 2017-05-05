using System.Data.Entity;

namespace DemoMoq.DataLayer
{
    class UnitOfWorkManager : IUnitOfWorkManager
    {
        private bool _isDisposed;
        private readonly DataContext _dataContext;

        public UnitOfWorkManager(IDataContext dataContext)
        {
            Database.SetInitializer<DataContext>(null);
            _dataContext = dataContext as DataContext;
        }

        public IUnitOfWork NewUnitOfWork()
        {
            return new UnitOfWork(_dataContext);
        }

        public void Dispose()
        {
            if (_isDisposed) return;

            _dataContext.Dispose();
            _isDisposed = true;
        }
    }
}
