
using api.Dtos;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<Employee> _employeeRepository;
        public EmployeeController(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employeeModel = await _employeeRepository.GetByIdAsync(id);
            //Console.WriteLine(employeeModel);
            if (employeeModel == null)
            {
                return NotFound();
            }
            return Ok(employeeModel.ToEmployeeDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var employeeModel = await _employeeRepository.DeleteById(id);
            if (employeeModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}