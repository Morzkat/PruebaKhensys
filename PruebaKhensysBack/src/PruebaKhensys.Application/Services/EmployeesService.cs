using FluentValidation;
using PruebaKhensys.Core.Entities.Common;
using PruebaKhensys.Core.Entities.DTOS;
using PruebaKhensys.Core.Entities.Models;
using PruebaKhensys.Core.Interfaces.Persistence;
using PruebaKhensys.Core.Interfaces.Services;
using PruebaKhensys.Infrastructure.AppMapper;
using PruebaKhensys.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaKhensys.Application.Services
{
    public class EmployeesService : IEmployeesService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppMapper _appMapper;
        private readonly IValidator<EmployeeDTO> _employeeValidator;

        public EmployeesService(IUnitOfWork unitOfWork, IAppMapper appMapper, IValidator<EmployeeDTO> employeeValidator)
        {
            _appMapper = appMapper;
            _unitOfWork = unitOfWork;
            _employeeValidator = employeeValidator;
        }

        public async Task<Result<HttpResponse>> AddEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                var validationResult = await _employeeValidator.ValidateAsync(employeeDTO);
                if (validationResult.IsValid)
                {
                    var exist = await _unitOfWork.EmployeesRepositories.ExistAsync(r => r.Id == employeeDTO.Id);
                    if (exist)
                        return HttpResponseHelper.NewResult(HttpStatusCode.Conflict, HttpResponseHelper.NewHttpResponse(error: "The employee already exist."));

                    var employee = _appMapper.MapToANew<EmployeeDTO, Employee>(employeeDTO);
                    var excuseType = _unitOfWork.ExcuseTypesRepositories.GetById(employee.ExcuseType.Id);
                    
                    if (excuseType != null)
                        employee.ExcuseType = excuseType;
                    
                    await _unitOfWork.EmployeesRepositories.AddAsync(employee);
                    var transactionNumber = await _unitOfWork.CompleteAsync();

                    //Logger:
                    return HttpResponseHelper.NewResult(HttpStatusCode.Created, HttpResponseHelper.NewHttpResponse("New employee added", success: true));
                }
                return HttpResponseHelper.NewResult(HttpStatusCode.Ok, HttpResponseHelper.NewHttpResponse(error: validationResult.Errors.ValidationsErrors()));
            }
            catch (Exception e)
            {
                // _logger:
                return HttpResponseHelper.NewResult(HttpStatusCode.InternalServerError, HttpResponseHelper.NewHttpResponse(error: e.Message));
            }
        }

        public async Task<Result<HttpResponse>> DeleteEmployee(int employeeId)
        {
            try
            {
                var exist = await _unitOfWork.EmployeesRepositories.ExistAsync(r => r.Id == employeeId);
                if (!exist)
                    return HttpResponseHelper.NewResult(HttpStatusCode.BadRequest, HttpResponseHelper.NewHttpResponse(error: "The employee doesn't exist."));

                var employee = await _unitOfWork.EmployeesRepositories.GetByIdAsync(employeeId);
                await _unitOfWork.EmployeesRepositories.DeleteAsync(employee);
                //Logger:
                var transactionNumber = await _unitOfWork.CompleteAsync();
                return HttpResponseHelper.NewResult(HttpStatusCode.Ok, HttpResponseHelper.NewHttpResponse(message: "The employee was deleted it.", success: true));

            }
            catch (Exception e)
            {
                // _logger:
                return HttpResponseHelper.NewResult(HttpStatusCode.InternalServerError, HttpResponseHelper.NewHttpResponse(error: e.Message));
            }
        }

        public async Task<Result<HttpResponseWithElement<EmployeeDTO>>> GetEmployee(int employeeId)
        {
            try
            {
                var exist = await _unitOfWork.EmployeesRepositories.ExistAsync(r => r.Id == employeeId);
                if (!exist)
                    return HttpResponseHelper.NewResult(HttpStatusCode.BadRequest, HttpResponseHelper.NewHttpResponseWithElement<EmployeeDTO>(error: "The employee doesn't exist."));

                var employee = await _unitOfWork.EmployeesRepositories.GetByIdAsync(employeeId, new List<string> { "ExcuseType" });
                var employeeDTO = _appMapper.MapToANew<Employee, EmployeeDTO>(employee);
                //Logger:
                return HttpResponseHelper.NewResult(HttpStatusCode.Ok, HttpResponseHelper.NewHttpResponseWithElement(element: employeeDTO, success: true));

            }
            catch (Exception e)
            {
                // _logger:
                return HttpResponseHelper.NewResult(HttpStatusCode.InternalServerError, HttpResponseHelper.NewHttpResponseWithElement<EmployeeDTO>(error: e.Message));
            }
        }

        public async Task<Result<HttpResponseWithList<EmployeeDTO>>> GetEmployees(Pagination pagination = null)
        {
            try
            {
                var employees = await _unitOfWork.EmployeesRepositories.GetAllAsync(entitiesToInclude: new List<string> { "ExcuseType" });
                var employeesDTO = _appMapper.MapToANew<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(employees);
                //Logger:
                return HttpResponseHelper.NewResult(HttpStatusCode.Ok, HttpResponseHelper.NewHttpResponseList(elements: employeesDTO, success: true));
            }
            catch (Exception e)
            {
                // _logger:
                return HttpResponseHelper.NewResult(HttpStatusCode.InternalServerError, HttpResponseHelper.NewHttpResponseList<EmployeeDTO>(error: e.Message));
            }
        }

        public async Task<Result<HttpResponse>> UpdateEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                var validationResult = await _employeeValidator.ValidateAsync(employeeDTO);
                if (validationResult.IsValid)
                {
                    var exist = await _unitOfWork.EmployeesRepositories.ExistAsync(r => r.Id == employeeDTO.Id);
                    if (!exist)
                        return HttpResponseHelper.NewResult(HttpStatusCode.Conflict, HttpResponseHelper.NewHttpResponse(error: "The employee doesn't exist."));
                   
                    var rolExist = await _unitOfWork.ExcuseTypesRepositories.ExistAsync(r => r.Id == employeeDTO.ExcuseType.Id);
                    if (!rolExist)
                        return HttpResponseHelper.NewResult(HttpStatusCode.Conflict, HttpResponseHelper.NewHttpResponse(error: "The excuseType doesn't exist."));

                    var employee = _appMapper.MapToANew<EmployeeDTO, Employee>(employeeDTO);
                    await _unitOfWork.EmployeesRepositories.UpdateAsync(employee);
                    var transactionNumber = await _unitOfWork.CompleteAsync();
                    //Logger:
                    return HttpResponseHelper.NewResult(HttpStatusCode.Ok, HttpResponseHelper.NewHttpResponse("The employee was updated it", success: true));
                }
                return HttpResponseHelper.NewResult(HttpStatusCode.Ok, HttpResponseHelper.NewHttpResponse(error: validationResult.Errors.ValidationsErrors()));
            }
            catch (Exception e)
            {
                // _logger:
                return HttpResponseHelper.NewResult(HttpStatusCode.InternalServerError, HttpResponseHelper.NewHttpResponse(error: e.Message));
            }
        }
    }
}
