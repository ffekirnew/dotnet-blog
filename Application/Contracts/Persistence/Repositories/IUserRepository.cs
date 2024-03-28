using BlogApp.Domain.Entitites;

namespace BlogApp.Application.Contracts.Persistence.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
  Task<User> GetUserByEmail(string email);
}
