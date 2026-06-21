namespace api.Interfaces
{
     public interface IRepository<T>
    {
        public Task<List<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(int id);

        public Task<T> SaveAsync(T entity);

        public Task<T?> UpdateAsync(int id, T entity);
        public Task<T?> DeleteById(int id);
    }
}
