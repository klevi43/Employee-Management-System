using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly ApplicationDBContext _context;

        public EmployeeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Employee?> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            // Created a possible dependency cycle. when only including .Include()
            // Employee Depends on Dept. Dept depends on Employee
            // fix create a dto
            // after include use .Select() to map to Dto
            return await _context.Employees.Include(e => e.Department.Id).ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.Id == id);

        }

        public  async Task<Employee> SaveAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee?> UpdateAsync(int id, Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}