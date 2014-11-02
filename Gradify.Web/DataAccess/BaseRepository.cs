using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Gradify.Web.Domain;

namespace Gradify.Web.DataAccess
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : DomainEntity
    {

        private readonly IUnitOfWork _uow;

        public BaseRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public virtual int Add(T entity)
        {
            _uow.Set<T>().Add(entity);
            _uow.Commit();
            return entity.Id;
        }

        public virtual T FindById(int id)
        {
            return _uow.Set<T>().SingleOrDefault(o => o.Id == id);
        }

        public virtual IEnumerable<T> FindAll()
        {
            return _uow.Set<T>().ToList();
        }

        public virtual void Update(T entity)
        {
            _uow.Set<T>().Attach(entity);
            _uow.Entry(entity).State = EntityState.Modified;

            _uow.Commit();
        }

        public virtual void Delete(T entity)
        {
            _uow.Set<T>().Remove(entity);
            _uow.Commit();
        }


        public void ForceCommit()
        {
            _uow.Commit();
        }
    }
}