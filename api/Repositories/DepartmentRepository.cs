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
        
        public Task<List<Department>> GetAllAsync()
        {
            return _context.Departments.ToListAsync();
        }
    }
}