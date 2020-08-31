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
    public class ExcuseTypesController : ControllerBase
    {
        private readonly IExcuseTypesService _excuseTypesService;

        public ExcuseTypesController(IExcuseTypesService ExcuseTypesService)
        {
            _excuseTypesService = ExcuseTypesService;
        }

        // GET: api/<ExcuseTypesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExcuseTypeDTO>>> Get()
        {
            var result = await _excuseTypesService.GetExcuseTypes(null);
            return StatusCode(result.StatusCode, result.HttpResponse);
        }

        // GET api/<ExcuseTypesController>/5
        [HttpGet("{excuseTypeId}")]
        public async Task<ActionResult<ExcuseTypeDTO>> Get(int excuseTypeId)
        {
            var result = await _excuseTypesService.GetExcuseType(excuseTypeId);
            return StatusCode(result.StatusCode, result.HttpResponse);
        }

        // POST api/<ExcuseTypesController>
        [HttpPost]
        public async Task<ActionResult<ExcuseTypeDTO>> Post([FromBody] ExcuseTypeDTO excuseTypeDTO)
        {
            var result = await _excuseTypesService.AddExcuseType(excuseTypeDTO);
            return StatusCode(result.StatusCode, result.HttpResponse);
        }

        // PUT api/<ExcuseTypesController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ExcuseTypeDTO excuseTypeDTO)
        {
            var result = await _excuseTypesService.UpdateExcuseType(excuseTypeDTO);
            return StatusCode(result.StatusCode, result.HttpResponse);
        }

        // DELETE api/<ExcuseTypesController>/5
        [HttpDelete("{excuseTypeId}")]
        public async Task<ActionResult<ExcuseTypeDTO>> Delete(int excuseTypeId)
        {
            var result = await _excuseTypesService.DeleteExcuseType(excuseTypeId);
            return StatusCode(result.StatusCode, result.HttpResponse);
        }
    }
}
