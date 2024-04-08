namespace BlogApp.Application.Contracts.Persistence.Repositories;


public interface IUnitOfWork : IDisposable
{
  IUserRepository UserRepository { get; }
}
