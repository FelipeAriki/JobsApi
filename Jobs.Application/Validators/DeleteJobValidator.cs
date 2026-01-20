using FluentValidation;
using Jobs.Application.Commands.DeleteJob;

namespace Jobs.Application.Validators;

public class DeleteJobValidator : AbstractValidator<DeleteJobCommand>
{
    public DeleteJobValidator()
    {
        RuleFor(j => j.Id)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}
