using Gradify.Web.Domain;

namespace Gradify.Web.DataAccess
{
    public class GradeRepository : BaseRepository<Grade>, IGradeRepository
    {
        public GradeRepository(IUnitOfWork uow) : base(uow)
        {
        }
    }
}