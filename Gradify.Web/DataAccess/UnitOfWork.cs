using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Gradify.Web.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly DbContext _context;
        private bool _isDisposed;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public DbSet<T> Set<T>() where T : class
        {
            return _context.Set<T>();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_isDisposed)
                return;

            _isDisposed = true;
            _context.Dispose();
        }
        public DbEntityEntry Entry<T>(T entity) where T : class
        {
            return _context.Entry(entity);
        }
    }
}