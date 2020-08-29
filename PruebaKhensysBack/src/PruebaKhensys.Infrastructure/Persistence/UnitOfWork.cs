using PruebaKhensys.Core.Interfaces.Persistence;
using PruebaKhensys.Core.Interfaces.Persistence.Repositories;
using PruebaKhensys.Infrastructure.Persistence.Context;
using PruebaKhensys.Infrastructure.Persistence.Repositories;
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
        private readonly PruebaKhensysContext _pruebaKhensysContext;

        public UnitOfWork(PruebaKhensysContext pruebaKhensysContext)
        {
            _pruebaKhensysContext = pruebaKhensysContext;

            //TODO: 
            RolesRepositories = new RoleRepository(_pruebaKhensysContext.Roles);
            EmployeesRepositories = new EmployeeRepository(_pruebaKhensysContext.Employees);
        }

        public int Complete() => _pruebaKhensysContext.SaveChanges();

        public async Task<int> CompleteAsync() => await _pruebaKhensysContext.SaveChangesAsync();

        public void Dispose() => _pruebaKhensysContext.Dispose();
    }
}
