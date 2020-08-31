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
    public class ExcuseTypesService : IExcuseTypesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppMapper _appMapper;
        private readonly IValidator<ExcuseTypeDTO> _excuseTypeValidator;

        public ExcuseTypesService(IUnitOfWork unitOfWork, IAppMapper appMapper, IValidator<ExcuseTypeDTO> excuseTypeValidator)
        {
            _appMapper = appMapper;
            _unitOfWork = unitOfWork;
            _excuseTypeValidator = excuseTypeValidator;
        }

        public async Task<Result<HttpResponse>> AddExcuseType(ExcuseTypeDTO excuseTypeDTO)
        {
            try
            {
                var validationResult = await _excuseTypeValidator.ValidateAsync(excuseTypeDTO);
                if (validationResult.IsValid)
                {
                    var exist = await _unitOfWork.ExcuseTypesRepositories.ExistAsync(r => r.Id == excuseTypeDTO.Id);
                    if (exist)
                        return HttpResponseHelper.NewResult(HttpStatusCode.Conflict, HttpResponseHelper.NewHttpResponse(error: "The excuseType already exist."));

                    var excuseType = _appMapper.MapToANew<ExcuseTypeDTO, ExcuseType>(excuseTypeDTO);
                    await _unitOfWork.ExcuseTypesRepositories.AddAsync(excuseType);
                    var transactionNumber = await _unitOfWork.CompleteAsync();

                    //Logger:
                    return HttpResponseHelper.NewResult(HttpStatusCode.Created, HttpResponseHelper.NewHttpResponse("New excuseType added", success: true));
                }
                return HttpResponseHelper.NewResult(HttpStatusCode.Ok, HttpResponseHelper.NewHttpResponse(error: validationResult.Errors.ValidationsErrors()));
            }
            catch (Exception e)
            {
                // _logger:
                return HttpResponseHelper.NewResult(HttpStatusCode.InternalServerError, HttpResponseHelper.NewHttpResponse(error: e.Message));
            }
        }

        public async Task<Result<HttpResponse>> DeleteExcuseType(int excuseTypeId)
        {
            try
            {
                var exist = await _unitOfWork.ExcuseTypesRepositories.ExistAsync(r => r.Id == excuseTypeId);
                if (!exist)
                    return HttpResponseHelper.NewResult(HttpStatusCode.BadRequest, HttpResponseHelper.NewHttpResponse(error: "The excuseType doesn't exist."));

                var excuseType = await _unitOfWork.ExcuseTypesRepositories.GetByIdAsync(excuseTypeId);
                await _unitOfWork.ExcuseTypesRepositories.DeleteAsync(excuseType);
                //Logger:
                var transactionNumber = await _unitOfWork.CompleteAsync();
                return HttpResponseHelper.NewResult(HttpStatusCode.Ok, HttpResponseHelper.NewHttpResponse(message: "The excuseType was deleted it.", success: true));
            }
            catch (Exception e)
            {
                // _logger:
                return HttpResponseHelper.NewResult(HttpStatusCode.InternalServerError, HttpResponseHelper.NewHttpResponse(error: e.Message));
            }
        }

        public async Task<Result<HttpResponseWithElement<ExcuseTypeDTO>>> GetExcuseType(int excuseTypeId)
        {
            try
            {
                var exist = await _unitOfWork.ExcuseTypesRepositories.ExistAsync(r => r.Id == excuseTypeId);
                if (!exist)
                    return HttpResponseHelper.NewResult(HttpStatusCode.BadRequest, HttpResponseHelper.NewHttpResponseWithElement<ExcuseTypeDTO>(error: "The excuseType doesn't exist."));

                var excuseType = await _unitOfWork.ExcuseTypesRepositories.GetByIdAsync(excuseTypeId);
                var excuseTypeDTO = _appMapper.MapToANew<ExcuseType, ExcuseTypeDTO>(excuseType);
                //Logger:
                return HttpResponseHelper.NewResult(HttpStatusCode.Ok, HttpResponseHelper.NewHttpResponseWithElement(element: excuseTypeDTO, success: true));

            }
            catch (Exception e)
            {
                // _logger:
                return HttpResponseHelper.NewResult(HttpStatusCode.InternalServerError, HttpResponseHelper.NewHttpResponseWithElement<ExcuseTypeDTO>(error: e.Message));
            }
        }

        public async Task<Result<HttpResponseWithList<ExcuseTypeDTO>>> GetExcuseTypes(Pagination pagination = null)
        {
            try
            {
                var excuseTypes = await _unitOfWork.ExcuseTypesRepositories.GetAllAsync();
                var excuseTypesDTO = _appMapper.MapToANew<IEnumerable<ExcuseType>, IEnumerable<ExcuseTypeDTO>>(excuseTypes);
                //Logger:
                return HttpResponseHelper.NewResult(HttpStatusCode.Ok, HttpResponseHelper.NewHttpResponseList(elements: excuseTypesDTO, success: true));
            }
            catch (Exception e)
            {
                // _logger:
                return HttpResponseHelper.NewResult(HttpStatusCode.InternalServerError, HttpResponseHelper.NewHttpResponseList<ExcuseTypeDTO>(error: e.Message));
            }
        }

        public async Task<Result<HttpResponse>> UpdateExcuseType(ExcuseTypeDTO excuseTypeDTO)
        {
            try
            {
                var validationResult = await _excuseTypeValidator.ValidateAsync(excuseTypeDTO);
                if (validationResult.IsValid)
                {
                    var exist = await _unitOfWork.ExcuseTypesRepositories.ExistAsync(r => r.Id == excuseTypeDTO.Id);
                    if (!exist)
                        return HttpResponseHelper.NewResult(HttpStatusCode.Conflict, HttpResponseHelper.NewHttpResponse(error: "The excuseType doesn't exist."));

                    var excuseType = _appMapper.MapToANew<ExcuseTypeDTO, ExcuseType>(excuseTypeDTO);
                    await _unitOfWork.ExcuseTypesRepositories.UpdateAsync(excuseType);
                    var transactionNumber = await _unitOfWork.CompleteAsync();
                    //Logger:
                    return HttpResponseHelper.NewResult(HttpStatusCode.Ok, HttpResponseHelper.NewHttpResponse("The excuseType was updated it", success: true));
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
