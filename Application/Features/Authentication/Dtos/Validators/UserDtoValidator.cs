namespace BlogApp.Application.Features.Authentication.Dtos.Validators;

using FluentValidation;
using BlogApp.Application.Features.Authentication.Dtos;

public class UserDtoValidator : AbstractValidator<IUserDto>
{
  public UserDtoValidator()
  {
    RuleFor(u => u.UserName)
        .NotEmpty()
        .WithMessage("{PropertyName} is required.")
        .MaximumLength(20)
        .WithMessage("{PropertyName} must not exceed 20 characters.")
        .MinimumLength(3)
        .WithMessage("{PropertyName} must be at least 3 characters.");

    RuleFor(u => u.Password)
        .NotEmpty()
        .WithMessage("{PropertyName} is required.")
        .MaximumLength(15)
        .WithMessage("{PropertyName} must not exceed 15 characters.")
        .MinimumLength(6)
        .WithMessage("{PropertyName} must be at least 6 characters.");
  }
}
