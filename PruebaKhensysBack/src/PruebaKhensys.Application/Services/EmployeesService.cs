using PruebaKhensys.Core.Entities.Common;
using PruebaKhensys.Core.Entities.DTOS;
using PruebaKhensys.Core.Entities.Models;
using PruebaKhensys.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaKhensys.Application.Services
{
    public class EmployeesService : IEmployeesService
    {
        public Task<Result<HttpResponse>> AddEmployee(EmployeeDTO employeeDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Result<HttpResponse>> DeleteEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<HttpResponseWithElement<EmployeeDTO>>> GetEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<HttpResponseWithList<EmployeeDTO>>> GetEmployees(Pagination pagination = null)
        {
            throw new NotImplementedException();
        }

        public Task<Result<HttpResponse>> UpdateEmployee(EmployeeDTO employeeDTO)
        {
            throw new NotImplementedException();
        }
    }
}
