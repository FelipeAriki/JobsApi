using FluentValidation;
using Jobs.Application.Commands.User.CreateUser;

namespace Jobs.Application.Validators.User;

public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(u => u.FullName)
            .NotEmpty()
            .WithMessage("Nome inválido.");

        RuleFor(u => u.Email)
            .EmailAddress()
            .WithMessage("Email inválido.");

        RuleFor(u => u.BirthDate)
                .Must(d => d < DateTime.Now.AddYears(-18))
                    .WithMessage("Deve ser maior de idade.");
        RuleFor(u => u.Role)
            .NotEmpty()
            .WithMessage("Cargo inválido.");
    }
}
