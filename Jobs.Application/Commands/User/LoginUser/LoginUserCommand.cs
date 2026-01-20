using Jobs.Application.ViewModel;
using MediatR;

namespace Jobs.Application.Commands.User.LoginUser;

public class LoginUserCommand : IRequest<ResultViewModel<LoginViewModel>>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
