using api.Models;

namespace api.Interfaces
{
    public interface IDepartmentRepository
    {
        public Task<List<Department>> GetAllAsync();
        public Task<Department?> GetByIdAsync(int id);

        public Task<Department> SaveAsync(Department department);

        public Task<Department?> UpdateAsync(Department department);
        public void DeleteById(int id);
    }
}