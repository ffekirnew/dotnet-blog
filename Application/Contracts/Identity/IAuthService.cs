namespace BlogApp.Application.Contracts.Identity;

using BlogApp.Application.Common.Responses;
using BlogApp.Application.Contracts.Identity.Models;

public interface IAuthService
{
  Task<Result<AuthResponse>> Login(AuthRequest authRequest);
  Task<Result<RegistrationResponse>> Register(RegistrationRequest registrationRequest);
}
