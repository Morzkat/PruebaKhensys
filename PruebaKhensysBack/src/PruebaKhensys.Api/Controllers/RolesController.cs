using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaKhensys.Core.Entities.DTOS;
using PruebaKhensys.Core.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaKhensys.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;

        public RolesController(IRolesService RolesService)
        {
            _rolesService = RolesService;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDTO>>> Get()
        {
            var result = await _rolesService.GetRoles(null);
            return StatusCode(result.StatusCode, result.HttpResponse);
        }

        // GET api/<RolesController>/5
        [HttpGet("{roleId}")]
        public async Task<ActionResult<RoleDTO>> Get(int roleId)
        {
            var result = await _rolesService.GetRole(roleId);
            return StatusCode(result.StatusCode, result.HttpResponse);
        }

        // POST api/<RolesController>
        [HttpPost]
        public async Task<ActionResult<RoleDTO>> Post([FromBody] RoleDTO roleDTO)
        {
            var result = await _rolesService.AddRole(roleDTO);
            return StatusCode(result.StatusCode, result.HttpResponse);
        }

        // PUT api/<RolesController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RoleDTO roleDTO)
        {
            var result = await _rolesService.UpdateRole(roleDTO);
            return StatusCode(result.StatusCode, result.HttpResponse);
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{roleId}")]
        public async Task<ActionResult<RoleDTO>> Delete(int roleId)
        {
            var result = await _rolesService.DeleteRole(roleId);
            return StatusCode(result.StatusCode, result.HttpResponse);
        }
    }
}
