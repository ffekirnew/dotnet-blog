namespace BlogApp.Application.Features.Authentication.Dtos.Validators;

using FluentValidation;

using BlogApp.Application.Features.Authentication.Dtos;

public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
{
  public LoginUserDtoValidator()
  {
    Include(new UserDtoValidator());
  }
}
