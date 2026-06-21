namespace api.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set;} = string.Empty;
        public List<EmployeeDto> EmployeeDtos { get; set; } = new List<EmployeeDto>();

    }
}