using FluentValidation;
using Jobs.Application.Queries.User.GetUserById;

namespace Jobs.Application.Validators.User;

public class GetUserByIdValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdValidator()
    {
        RuleFor(j => j.Id)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0);
    }
}
