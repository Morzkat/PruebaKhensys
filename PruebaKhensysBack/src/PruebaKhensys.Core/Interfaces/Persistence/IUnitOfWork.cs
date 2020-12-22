using System;
using System.Threading.Tasks;
using PruebaKhensys.Core.Interfaces.Persistence.Repositories;

namespace PruebaKhensys.Core.Interfaces.Persistence
{
    public interface IUnitOfWork :  IDisposable
    {
        IExcuseTypesRepositories ExcuseTypesRepositories { get; set; }
        IEmployeesRepositories EmployeesRepositories { get; set; }

        int Complete();
        Task<int> CompleteAsync();
    }
}