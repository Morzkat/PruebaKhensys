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
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> Get()
        {
            var result = await _employeesService.GetEmployees(null);
            return StatusCode(result.StatusCode, result.HttpResponse);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{employeeId}")]
        public async Task<ActionResult<EmployeeDTO>> Get(int employeeId)
        {
            var result = await _employeesService.GetEmployee(employeeId);
            return StatusCode(result.StatusCode, result.HttpResponse);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> Post([FromBody] EmployeeDTO employeeDTO)
        {
            var result = await _employeesService.AddEmployee(employeeDTO);
            return StatusCode(result.StatusCode, result.HttpResponse);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EmployeeDTO employeeDTO)
        {
            var result = await _employeesService.UpdateEmployee(employeeDTO);
            return StatusCode(result.StatusCode, result.HttpResponse);
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{employeeId}")]
        public async Task<ActionResult<EmployeeDTO>> Delete(int employeeId)
        {
            var result = await _employeesService.DeleteEmployee(employeeId);
            return StatusCode(result.StatusCode, result.HttpResponse);
        }
    }
}
