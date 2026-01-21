using Jobs.Application.ViewModel;
using MediatR;

namespace Jobs.Application.Commands.User.Password.PasswordRecovery;

public class PasswordRecoveryCommand : IRequest<ResultViewModel>
{
    public string Email { get; set; }
}
