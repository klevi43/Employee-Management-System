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
                DepartmentId = employeeModel.DepartmentId
            };
        }

        public static Employee ToEmployeeFromCreate(this CreateEmployeeRequestDto employeeRequestDto)
        {
            return new Employee
            {
                FirstName = employeeRequestDto.FirstName,
                LastName = employeeRequestDto.LastName,
                StartDate = employeeRequestDto.StartDate,
                EndDate = null,
                DepartmentId = employeeRequestDto.DepartmentId
            };
        }
        public static Employee ToEmployeeFromUpdate(this UpdateEmployeeRequestDto employeeRequestDto)
        {
            return new Employee
            {
                FirstName = employeeRequestDto.FirstName,
                LastName = employeeRequestDto.LastName,
                StartDate = employeeRequestDto.StartDate,
                EndDate = employeeRequestDto.EndDate,
                DepartmentId = employeeRequestDto.DepartmentId
            };
        }
    }
}