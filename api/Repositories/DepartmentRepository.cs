using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {   
        private readonly ApplicationDBContext _context;
        public DepartmentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        // Task a unit of work that will produce a value in the future
        // sounds a lot like a promise
        public async Task<List<Department>> GetAllAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            // This returns the requested dept or null handle exception in service layer
            return await _context.Departments.Include(d => d.Employees).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Department> SaveAsync(Department department)
        {
            await _context.AddAsync(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public Task<Department?> UpdateAsync(Department department)
        {
            throw new NotImplementedException();
        }
    }
}