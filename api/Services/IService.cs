using api.Models;

namespace api.Services
{
    public interface IService<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        
    }
}