using PruebaKhensys.Core.Interfaces.Persistence;
using PruebaKhensys.Core.Interfaces.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaKhensys.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRolesRepositories RolesRepositories { get; set; }
        public IEmployeesRepositories EmployeesRepositories { get; set; }

        public int Complete()
        {
            throw new NotImplementedException();
        }

        public Task<int> CompleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
