
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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeRequestDto employeeRequestDto)
        {
            var employeeModel = employeeRequestDto.ToEmployeeFromCreate();
            await _employeeRepository.SaveAsync(employeeModel);
            return CreatedAtAction(nameof(GetById), new { id = employeeModel.Id }, employeeModel.ToEmployeeDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody] UpdateEmployeeRequestDto employeeRequestDto)
        {
            var employeeModel = employeeRequestDto.ToEmployeeFromUpdate();
            var updatedEmployee = await _employeeRepository.UpdateAsync(id, employeeModel);
            if (updatedEmployee == null)
            {
                return NotFound();
            }
            
            return Ok(updatedEmployee.ToEmployeeDto());
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