using api.Data;
using api.Models;

namespace api.Services
{
    public class DepartmentService : IService<Department>
    {
        private readonly ApplicationDBContext _context;
        public DepartmentService(ApplicationDBContext context)
        {
            _context = context;
        }

        public void Add(Department entity)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAll()
        {
            throw new NotImplementedException();
        }

        public Department GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}