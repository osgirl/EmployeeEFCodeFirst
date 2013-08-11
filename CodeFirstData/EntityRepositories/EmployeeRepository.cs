using CodeFirstData.DBInteractions;
using CodeFirstEntities;

namespace CodeFirstData.EntityRepositories
{
    public class EmployeeRepository : EntityRepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDBFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

}