using FluentValidation;
using Jobs.Application.Commands.UpdateJob;

namespace Jobs.Application.Validators;

public class UpdateJobValidator : AbstractValidator<UpdateJobCommand>
{
    public UpdateJobValidator()
    {
        RuleFor(j => j.Id)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);

        RuleFor(j => j.Title)
                .NotEmpty().WithMessage("Título inválido.");

        RuleFor(j => j.Description)
                .NotEmpty().WithMessage("Descrição inválida.");

        RuleFor(j => j.Location)
                .NotEmpty().WithMessage("Localização inválida.");

        RuleFor(j => j.Salary)
            .GreaterThanOrEqualTo(1621).WithMessage("O Salário deve custar pelo menos R$1.621 (base do salário mínimo atual)");
    }
}
