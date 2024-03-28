using BlogApp.Application.Contracts.Identity.Models;

namespace BlogApp.Application.Contracts.Identity;

public interface IUserService
{
  Task<List<User>> GetUsers();
  Task<User?> GetUser(string userId);
}

