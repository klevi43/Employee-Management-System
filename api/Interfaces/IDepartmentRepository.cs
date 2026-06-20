using api.Models;

namespace api.Interfaces
{
    public interface IDepartmentRepository
    {
        public Task<List<Department>> GetAllAsync();
    }
}