using Jobs.Application.ViewModel;
using Jobs.Core.Repositories;
using Jobs.Infrastructure.Auth;
using MediatR;

namespace Jobs.Application.Commands.User.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResultViewModel<int>>
{
    private readonly IUserRepository _repository;
    private readonly IAuthService _authService;

    public CreateUserCommandHandler(IUserRepository repository, IAuthService authService)
    {
        _repository = repository;
        _authService = authService;
    }

    public async Task<ResultViewModel<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var hash = _authService.ComputeHash(request.Password);

        var user = request.ToEntity(hash);
        var idUserCreated = await _repository.CreateUserAsync(user);

        return ResultViewModel<int>.Success(idUserCreated);
    }
}
