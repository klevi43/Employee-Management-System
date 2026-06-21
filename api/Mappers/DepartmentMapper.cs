using api.Dtos;
using api.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace api.Mappers
{
    // These are extension methods
    public static class DepartmentMappers
    {
        public static DepartmentDto ToDepartmentDto(this Department departmentModel)
        {
            return new DepartmentDto
            {
                Id = departmentModel.Id,
                Name = departmentModel.Name,
                EmployeeDtos = departmentModel.Employees.Select(e => e.ToEmployeeDto()).ToList()
            };
        }

        public static Department ToDepartment(this CreateDepartmentRequestDto departmentRequestDto)
        {
            return new Department
            {
                Name = departmentRequestDto.Name
            };
        }
    }
}