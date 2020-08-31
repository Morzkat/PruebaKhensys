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
    public class RolesService : IRolesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppMapper _appMapper;
        private readonly IValidator<RoleDTO> _roleValidator;

        public RolesService(IUnitOfWork unitOfWork, IAppMapper appMapper, IValidator<RoleDTO> roleValidator)
        {
            _appMapper = appMapper;
            _unitOfWork = unitOfWork;
            _roleValidator = roleValidator;
        }

        public async Task<Result<HttpResponse>> AddRole(RoleDTO roleDTO)
        {
            try
            {
                var validationResult = await _roleValidator.ValidateAsync(roleDTO);
                if (validationResult.IsValid)
                {
                    var exist = await _unitOfWork.RolesRepositories.ExistAsync(r => r.Id == roleDTO.Id);
                    if (exist)
                        return HttpResponseHelper.NewResult(HttpStatusCode.Conflict, HttpResponseHelper.NewHttpResponse(error: "The role already exist."));

                    var role = _appMapper.MapToANew<RoleDTO, Role>(roleDTO);
                    await _unitOfWork.RolesRepositories.AddAsync(role);
                    var transactionNumber = await _unitOfWork.CompleteAsync();

                    //Logger:
                    return HttpResponseHelper.NewResult(HttpStatusCode.Created, HttpResponseHelper.NewHttpResponse("New role added", success: true));
                }
                return HttpResponseHelper.NewResult(HttpStatusCode.Ok, HttpResponseHelper.NewHttpResponse(error: validationResult.Errors.ValidationsErrors()));
            }
            catch (Exception e)
            {
                // _logger:
                return HttpResponseHelper.NewResult(HttpStatusCode.InternalServerError, HttpResponseHelper.NewHttpResponse(error: e.Message));
            }
        }

        public async Task<Result<HttpResponse>> DeleteRole(int roleId)
        {
            try
            {
                var exist = await _unitOfWork.RolesRepositories.ExistAsync(r => r.Id == roleId);
                if (!exist)
                    return HttpResponseHelper.NewResult(HttpStatusCode.BadRequest, HttpResponseHelper.NewHttpResponse(error: "The role doesn't exist."));

                var role = await _unitOfWork.RolesRepositories.GetByIdAsync(roleId);
                await _unitOfWork.RolesRepositories.DeleteAsync(role);
                //Logger:
                var transactionNumber = await _unitOfWork.CompleteAsync();
                return HttpResponseHelper.NewResult(HttpStatusCode.Ok, HttpResponseHelper.NewHttpResponse(message: "The role was deleted it.", success: true));
            }
            catch (Exception e)
            {
                // _logger:
                return HttpResponseHelper.NewResult(HttpStatusCode.InternalServerError, HttpResponseHelper.NewHttpResponse(error: e.Message));
            }
        }

        public async Task<Result<HttpResponseWithElement<RoleDTO>>> GetRole(int roleId)
        {
            try
            {
                var exist = await _unitOfWork.RolesRepositories.ExistAsync(r => r.Id == roleId);
                if (!exist)
                    return HttpResponseHelper.NewResult(HttpStatusCode.BadRequest, HttpResponseHelper.NewHttpResponseWithElement<RoleDTO>(error: "The role doesn't exist."));

                var role = await _unitOfWork.RolesRepositories.GetByIdAsync(roleId);
                var roleDTO = _appMapper.MapToANew<Role, RoleDTO>(role);
                //Logger:
                return HttpResponseHelper.NewResult(HttpStatusCode.Ok, HttpResponseHelper.NewHttpResponseWithElement(element: roleDTO, success: true));

            }
            catch (Exception e)
            {
                // _logger:
                return HttpResponseHelper.NewResult(HttpStatusCode.InternalServerError, HttpResponseHelper.NewHttpResponseWithElement<RoleDTO>(error: e.Message));
            }
        }

        public async Task<Result<HttpResponseWithList<RoleDTO>>> GetRoles(Pagination pagination = null)
        {
            try
            {
                var roles = await _unitOfWork.RolesRepositories.GetAllAsync();
                var rolesDTO = _appMapper.MapToANew<IEnumerable<Role>, IEnumerable<RoleDTO>>(roles);
                //Logger:
                return HttpResponseHelper.NewResult(HttpStatusCode.Ok, HttpResponseHelper.NewHttpResponseList(elements: rolesDTO, success: true));
            }
            catch (Exception e)
            {
                // _logger:
                return HttpResponseHelper.NewResult(HttpStatusCode.InternalServerError, HttpResponseHelper.NewHttpResponseList<RoleDTO>(error: e.Message));
            }
        }

        public async Task<Result<HttpResponse>> UpdateRole(RoleDTO roleDTO)
        {
            try
            {
                var validationResult = await _roleValidator.ValidateAsync(roleDTO);
                if (validationResult.IsValid)
                {
                    var exist = await _unitOfWork.RolesRepositories.ExistAsync(r => r.Id == roleDTO.Id);
                    if (!exist)
                        return HttpResponseHelper.NewResult(HttpStatusCode.Conflict, HttpResponseHelper.NewHttpResponse(error: "The role doesn't exist."));

                    var role = _appMapper.MapToANew<RoleDTO, Role>(roleDTO);
                    await _unitOfWork.RolesRepositories.UpdateAsync(role);
                    var transactionNumber = await _unitOfWork.CompleteAsync();
                    //Logger:
                    return HttpResponseHelper.NewResult(HttpStatusCode.Ok, HttpResponseHelper.NewHttpResponse("The role was updated it", success: true));
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
