using FluentValidation;
using Jobs.Application.Commands.User.DeleteUser;

namespace Jobs.Application.Validators.User;

public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserValidator()
    {
        RuleFor(j => j.Id)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}
