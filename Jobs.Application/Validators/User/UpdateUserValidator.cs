using FluentValidation;
using Jobs.Application.Commands.User.UpdateUser;

namespace Jobs.Application.Validators.User;

public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserValidator()
    {
        RuleFor(j => j.Id)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);

        RuleFor(u => u.FullName)
           .NotEmpty()
           .WithMessage("Nome inválido.");

        RuleFor(u => u.Email)
            .EmailAddress()
            .WithMessage("Email inválido.");

        RuleFor(u => u.BirthDate)
                .Must(d => d < DateTime.Now.AddYears(-18))
                    .WithMessage("Deve ser maior de idade.");
    }
}
