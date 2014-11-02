using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Gradify.Web.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        DbSet<T> Set<T>() where T : class;
        void Commit();
        DbEntityEntry Entry<T>(T entity) where T : class;
    }
}
