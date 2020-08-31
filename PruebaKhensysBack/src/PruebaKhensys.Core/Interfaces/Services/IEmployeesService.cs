using PruebaKhensys.Core.Entities.Common;
using PruebaKhensys.Core.Entities.DTOS;
using System.Threading.Tasks;

namespace PruebaKhensys.Core.Interfaces.Services
{
    public interface IEmployeesService
    {
        Task<Result<HttpResponse>> AddEmployee(EmployeeDTO employeeDTO);
        Task<Result<HttpResponse>> DeleteEmployee(int employeeId);
        Task<Result<HttpResponse>> UpdateEmployee(EmployeeDTO employeeDTO);
        Task<Result<HttpResponseWithElement<EmployeeDTO>>> GetEmployee(int employeeId);
        Task<Result<HttpResponseWithList<EmployeeDTO>>> GetEmployees(Pagination pagination = null);
    }
}
