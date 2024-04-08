using BlogApp.Application.Contracts.Persistence.Repositories;
using BlogApp.Domain.Entitites;

namespace BlogApp.Persistence.Repositories;


public class PostRepository : IPostRepository
{
  private readonly BlogAppDbContext _dbContext;
  public PostRepository(BlogAppDbContext dbContext)
  {
    _dbContext = dbContext;
  }
  public Task<Post> AddAsync(Post entity)
  {
    throw new NotImplementedException();
  }

  public Task DeleteAsync(Post enity)
  {
    throw new NotImplementedException();
  }

  public Task<Post> GetAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<List<Post>> GetAsync()
  {
    throw new NotImplementedException();
  }

  public Task UpdateAsync(Post enity)
  {
    throw new NotImplementedException();
  }
}
