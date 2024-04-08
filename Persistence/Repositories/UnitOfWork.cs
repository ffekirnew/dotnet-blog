using BlogApp.Application.Contracts.Persistence.Repositories;

namespace BlogApp.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
  private readonly BlogAppDbContext _dbContext;

  private IUserRepository? _userRepository;
  private IPostRepository? _postRepository;


  public UnitOfWork(BlogAppDbContext dbContext) => _dbContext = dbContext;

  public IUserRepository UserRepository
  {
    get => _userRepository ??= new UserRepository(_dbContext);
  }

  public IPostRepository PostRepository
  {
    get => _postRepository ??= new PostRepository(_dbContext);
  }

  public async Task<int> SaveAsync()
  {
    return await _dbContext.SaveChangesAsync();
  }

  public void Dispose()
  {
    _dbContext.Dispose();
    GC.SuppressFinalize(this);
  }
}
