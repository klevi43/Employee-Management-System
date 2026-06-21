using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {   
        private readonly ApplicationDBContext _context;
        public DepartmentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Department?> DeleteById(int id)
        {
            
            var department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);
            if (department == null)
            {
                return null;
            }
            _context.Remove(department);
            await _context.SaveChangesAsync();
            return department;
        }

        // Task a unit of work that will produce a value in the future
        // sounds a lot like a promise
        public async Task<List<Department>> GetAllAsync()
        {
            return await _context.Departments.Include(d => d.Employees).ToListAsync();
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

        public async Task<Department?> UpdateAsync(int id, Department updatedDepartment) 
        {
            var existingDepartment = await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);
            if (existingDepartment == null)
            {
                return null;
            }

            existingDepartment.Name = updatedDepartment.Name;
            await _context.SaveChangesAsync();

            return existingDepartment;
        }
    }
}