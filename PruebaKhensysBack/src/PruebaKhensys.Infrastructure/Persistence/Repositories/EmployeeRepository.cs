using Microsoft.EntityFrameworkCore;
using PruebaKhensys.Core.Entities.Models;
using PruebaKhensys.Core.Interfaces.Persistence.Repositories;

namespace PruebaKhensys.Infrastructure.Persistence.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeesRepositories
    {
        public EmployeeRepository(DbSet<Employee> employees) : base (employees)
        {

        }
    }
}
