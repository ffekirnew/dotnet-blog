namespace BlogApp.Application.Features.Authentication.Handlers.Commands;

using MediatR;
using AutoMapper;

using BlogApp.Domain.Entitites;
using BlogApp.Application.Common.Responses;
using BlogApp.Application.Features.Authentication.Dtos;
using BlogApp.Application.Features.Authentication.Requests.Commands;
using BlogApp.Application.Contracts.Persistence.Repositories;
using BlogApp.Application.Features.Authentication.Dtos.Validators;
using BlogApp.Application.Contracts.Identity;

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
    var dtoValidator = new RegisterUserDtoValidator();
    var validationResult = dtoValidator.Validate(request.RegisterUserDto);

    if (validationResult.IsValid == false)
    {
      return new CommonResponse<LoggedInUserDto>
      {
        IsSuccess = false,
        Message = "User registration failed.",
        Error = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
      };
    }

    var userExists = await _authService.UsernameExists(
        request.RegisterUserDto.Username
    );

    if (userExists == true)
    {
      return new CommonResponse<LoggedInUserDto>
      {
        IsSuccess = false,
        Message = "User registration failed.",
        Error = new List<string> { "Username Exists." }
      };
    }

    userExists = await _authService.EmailExists(request.RegisterUserDto.Email);

    if (userExists == true)
    {
      return new CommonResponse<LoggedInUserDto>
      {
        IsSuccess = false,
        Message = "User registration failed.",
        Error = new List<string> { "Email Exists." }
      };
    }

    var authResponse = await _authService.Register(request.RegisterUserDto);

    var createdUser = _mapper.Map<User>(authResponse.User);


    return new CommonResponse<LoggedInUserDto>
    {
      IsSuccess = true,
      Message = "User registration success.",
      Value = new LoggedInUserDto { UserDto = _mapper.Map<UserDto>(createdUser), Token = authResponse.Token ?? "" }
    };
  }
}
