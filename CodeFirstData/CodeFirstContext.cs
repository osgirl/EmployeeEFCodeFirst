using System.Data.Entity;
using CodeFirstEntities;
namespace CodeFirstData
{
    public class CodeFirstContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
