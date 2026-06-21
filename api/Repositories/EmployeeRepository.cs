using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDBContext _context;

        public EmployeeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<List<EmployeeDto>> GetAllAsync()
        {
            // Created a possible dependency cycle. when only including .Include()
            // Employee Depends on Dept. Dept depends on Employee
            // fix create a dto
            // after include use .Select() to map to Dto
            return _context.Employees.Include(e => e.Department).Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    DepartmentId = e.Department.Id
                }).ToListAsync();
        }
        
    }
}