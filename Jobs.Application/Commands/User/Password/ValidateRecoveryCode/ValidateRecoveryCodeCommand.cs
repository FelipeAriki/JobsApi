using Jobs.Application.ViewModel;
using MediatR;

namespace Jobs.Application.Commands.User.Password.ValidateRecoveryCode;

public class ValidateRecoveryCodeCommand : IRequest<ResultViewModel>
{
    public string Email { get; set; }
    public string Code { get; set; }
}
