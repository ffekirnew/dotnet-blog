using BlogApp.Application.Contracts.Persistence.Repositories;
using BlogApp.Domain.Entitites;

namespace BlogApp.Persistence.Repositories;


public class UserRepository : IUserRepository
{
  private readonly BlogAppDbContext _dbContext;
  public UserRepository(BlogAppDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public Task<User> AddAsync(User entity)
  {
    throw new NotImplementedException();
  }

  public Task DeleteAsync(User enity)
  {
    throw new NotImplementedException();
  }

  public Task<User> GetAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<List<User>> GetAsync()
  {
    throw new NotImplementedException();
  }

  public Task<User> GetUserByEmail(string email)
  {
    throw new NotImplementedException();
  }

  public Task UpdateAsync(User enity)
  {
    throw new NotImplementedException();
  }
}
