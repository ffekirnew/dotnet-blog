namespace BlogApp.Application.Features.Authentication.Handlers.Commands;

using MediatR;
using AutoMapper;

using BlogApp.Application.Common.Responses;
using BlogApp.Application.Features.Authentication.Dtos;
using BlogApp.Application.Features.Authentication.Requests.Commands;
using BlogApp.Application.Contracts.Persistence.Repositories;
using BlogApp.Application.Contracts.Identity.Services;
using BlogApp.Application.Contracts.Identity.Models;

public class RegisterUserCommandHandler
    : IRequestHandler<RegisterUserCommand, CommonResponse<LoggedInUserDto>>
{
  private IUnitOfWork _unitOfWork;
  private IAuthService _authService;
  private IMapper _mapper;

  public RegisterUserCommandHandler(
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
      RegisterUserCommand request,
      CancellationToken cancellationToken
  )
  {
    var user = new RegisterUserRequest
    {
      UserName = request.RegisterUserDto.UserName,
      Email = request.RegisterUserDto.Email,
      Password = request.RegisterUserDto.Password
    };

    var registrationResponse = await _authService.RegisterUser(user);

    if (registrationResponse == null)
    {
      return new CommonResponse<LoggedInUserDto>
      {
        Errors = new List<string> { "User registration failed" }
      };
    }

    var loggedInUser = _mapper.Map<LoggedInUserDto>(registrationResponse.User);
    return CommonResponse<LoggedInUserDto>.Success(loggedInUser);
  }
}
