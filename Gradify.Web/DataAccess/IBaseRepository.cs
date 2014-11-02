using System.Collections.Generic;
using Gradify.Web.Domain;

namespace Gradify.Web.DataAccess
{
    public interface IBaseRepository<T> where T : DomainEntity
    {
        int Add(T entity);
        void Update(T entity);
        IEnumerable<T> FindAll();
        T FindById(int id);
        void Delete(T entity);
        void ForceCommit();
    }
}
