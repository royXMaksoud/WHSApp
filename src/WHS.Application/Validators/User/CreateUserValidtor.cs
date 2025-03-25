using FluentValidation;
using WHS.Application.DTO.User;

namespace WHS.Application.Validators.User;

public class CreateUserValidator : AbstractValidator<UserDto>
{
    public CreateUserValidator()
    {
        RuleFor(dto => dto.Email)
            .EmailAddress()
            .WithMessage("Please provide a valid email address");
    }
}