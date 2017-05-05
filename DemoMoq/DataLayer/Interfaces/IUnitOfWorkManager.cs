using System;

// ReSharper disable once CheckNamespace
namespace DemoMoq.DataLayer
{
   public interface IUnitOfWorkManager:IDisposable
    {
        IUnitOfWork NewUnitOfWork();
    }
}
