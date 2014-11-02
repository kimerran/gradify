using System.Data.Entity;
using Gradify.Web.Domain;

namespace Gradify.Web.DataAccess
{
    public class GradifyDb : DbContext
    {
        public GradifyDb()
            : base("GradifyDb")
        {

        }

        public DbSet<Grade> Grades { get; set; }
    }
}