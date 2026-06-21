namespace api.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int DepartmentId { get; set; }
    }
}