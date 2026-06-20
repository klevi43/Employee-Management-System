using api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return Ok(departments);
        }


    }
}