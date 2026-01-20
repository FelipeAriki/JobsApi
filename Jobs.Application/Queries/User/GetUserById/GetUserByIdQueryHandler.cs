using Jobs.Application.ViewModel;
using Jobs.Core.Repositories;
using MediatR;

namespace Jobs.Application.Queries.User.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ResultViewModel<UserViewModel>>
{
    private readonly IUserRepository _repository;

    public GetUserByIdQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<UserViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetUserByIdAsync(request.Id);

        if (user is null)
        {
            return ResultViewModel<UserViewModel>.Error("Usuário não encontrado.");
        }

        return ResultViewModel<UserViewModel>.Success(UserViewModel.FromEntity(user));
    }
}
