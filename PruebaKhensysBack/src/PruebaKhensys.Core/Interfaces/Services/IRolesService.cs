using PruebaKhensys.Core.Entities.Common;
using PruebaKhensys.Core.Entities.DTOS;
using System.Threading.Tasks;

namespace PruebaKhensys.Core.Interfaces.Services
{
    public interface IExcuseTypesService
    {
        Task<Result<HttpResponse>> AddExcuseType(ExcuseTypeDTO excuseTypeDTO);
        Task<Result<HttpResponse>> DeleteExcuseType(int excuseTypeId);
        Task<Result<HttpResponse>> UpdateExcuseType(ExcuseTypeDTO excuseTypeDTO);
        Task<Result<HttpResponseWithElement<ExcuseTypeDTO>>> GetExcuseType(int excuseTypeId);
        Task<Result<HttpResponseWithList<ExcuseTypeDTO>>> GetExcuseTypes(Pagination pagination = null);
    }
}
