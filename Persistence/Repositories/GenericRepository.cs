using BlogApp.Application.Contracts.Persistence.Repositories;

namespace BlogApp.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T>
{
  public Task<T> AddAsync(T entity)
  {
    throw new NotImplementedException();
  }

  public Task DeleteAsync(T enity)
  {
    throw new NotImplementedException();
  }

  public Task<T> GetAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<List<T>> GetAsync()
  {
    throw new NotImplementedException();
  }

  public Task UpdateAsync(T enity)
  {
    throw new NotImplementedException();
  }
}
