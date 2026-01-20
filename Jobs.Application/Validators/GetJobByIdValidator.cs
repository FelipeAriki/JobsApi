using FluentValidation;
using Jobs.Application.Queries.GetJobById;

namespace Jobs.Application.Validators;

public class GetJobByIdValidator : AbstractValidator<GetJobByIdQuery>
{
    public GetJobByIdValidator()
    {
        RuleFor(j => j.Id)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Id inválido");
    }
}
