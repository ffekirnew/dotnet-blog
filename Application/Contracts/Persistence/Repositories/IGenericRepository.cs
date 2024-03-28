namespace BlogApp.Application.Contracts.Persistence.Repositories;

public interface IGenericRepository<T>
{
  Task<T> GetAsync(int id);
  Task<List<T>> GetAsync();
  Task<T> AddAsync(T entity);
  Task UpdateAsync(T enity);
  Task DeleteAsync(T enity);
}
