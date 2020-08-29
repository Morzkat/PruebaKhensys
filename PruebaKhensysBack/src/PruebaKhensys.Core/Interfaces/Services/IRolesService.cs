using PruebaKhensys.Core.Entities.Common;
using PruebaKhensys.Core.Entities.DTOS;
using PruebaKhensys.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaKhensys.Core.Interfaces.Services
{
    public interface IRolesService
    {
        Task<Result<HttpResponse>> AddRole(RoleDTO roleDTO);
        Task<Result<HttpResponse>> DeleteRole(int roleId);
        Task<Result<HttpResponse>> UpdateRole(RoleDTO roleDTO);
        Task<Result<HttpResponseWithElement<RoleDTO>>> GetRole(int roleId);
        Task<Result<HttpResponseWithList<RoleDTO>>> GetRoles(Pagination pagination = null);
    }
}
