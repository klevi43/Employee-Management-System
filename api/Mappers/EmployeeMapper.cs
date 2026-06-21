using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class EmployeeMappers
    {
        public static EmployeeDto ToEmployeeDto(this Employee employeeModel)
        {
            return new EmployeeDto
            {
                Id = employeeModel.Id,
                FirstName = employeeModel.FirstName,
                LastName = employeeModel.LastName,
                StartDate = employeeModel.StartDate,
                EndDate = employeeModel.EndDate,
                DepartmentId = employeeModel.Department.Id
            };
        }
    }
}