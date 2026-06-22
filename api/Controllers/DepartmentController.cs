using api.Dtos;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace api.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IRepository<Department> _departmentRepository;
        public DepartmentController(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return Ok(departments.Select(d => d.ToDepartmentDto()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            
            return Ok(department.ToDepartmentDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDepartmentRequestDto departmentDto)
        {   
            var departmentModel = departmentDto.ToDepartmentFromCreate();
            await _departmentRepository.SaveAsync(departmentModel);
            
            return CreatedAtAction(nameof(GetById), new { id = departmentModel.Id }, departmentModel.ToDepartmentDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(int id, [FromBody] UpdateDepartmentRequestDto updateDepartmentRequestDto)
        {
            var departmentModel = updateDepartmentRequestDto.ToDepartmentFromUpdate();
            var updatedDepartment = await _departmentRepository.UpdateAsync(id, departmentModel);
            if (updatedDepartment == null)
            {
                return NotFound();
            }

            return Ok(updatedDepartment.ToDepartmentDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            
            var departmentModel = await _departmentRepository.DeleteById(id);
            if (departmentModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}