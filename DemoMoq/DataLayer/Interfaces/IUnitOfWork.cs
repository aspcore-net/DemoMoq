using System;

// ReSharper disable once CheckNamespace
namespace DemoMoq.DataLayer
{
   public interface IUnitOfWork:IDisposable
    {
        void Commit();
        void Rollback();
    }
}
