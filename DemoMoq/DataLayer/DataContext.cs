using System.Data.Entity;

namespace DemoMoq.DataLayer
{
    public sealed class DataContext : DbContext, IDataContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public new void Dispose() { }
    }
}
