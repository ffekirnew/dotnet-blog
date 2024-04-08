namespace BlogApp.Application.Features.Authentication.Handlers.Commands;

using MediatR;
using AutoMapper;

using BlogApp.Application.Common.Responses;
using BlogApp.Application.Features.Authentication.Dtos;
using BlogApp.Application.Features.Authentication.Requests.Commands;
using BlogApp.Application.Contracts.Persistence.Repositories;
using BlogApp.Application.Contracts.Identity.Services;
using BlogApp.Application.Contracts.Identity.Models;

public class LoginUserCommandHandler
    : IRequestHandler<LoginUserCommand, CommonResponse<LoggedInUserDto>>
{
  private IUnitOfWork _unitOfWork;
  private IAuthService _authService;
  private IMapper _mapper;

  public LoginUserCommandHandler(
      IUnitOfWork unitOfWork,
      IMapper mapper,
      IAuthService authService
  )
  {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
    _authService = authService;
  }

  public async Task<CommonResponse<LoggedInUserDto>> Handle(
      LoginUserCommand request,
      CancellationToken cancellationToken
  )
  {
    var user = new LoginUserRequest
    {
      UserName = request.LoginUserDto.UserName,
      Password = request.LoginUserDto.Password
    };

    var loginResponse = await _authService.LoginUser(user);
    Console.WriteLine("Login response: " + loginResponse);

    if (loginResponse == null)
    {
      return new CommonResponse<LoggedInUserDto>
      {
        Errors = new List<string> { "User login failed" }
      };
    }

    var loggedInUser = _mapper.Map<LoggedInUserDto>(loginResponse);
    return CommonResponse<LoggedInUserDto>.Success(loggedInUser);
  }
}
