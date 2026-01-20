using Jobs.Application.ViewModel;
using Jobs.Core.Repositories;
using MediatR;

namespace Jobs.Application.Queries.User.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, ResultViewModel<IEnumerable<UserViewModel>>>
{
    private readonly IUserRepository _repository;

    public GetUsersQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<IEnumerable<UserViewModel>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _repository.GetUsersAsync();
        var model = users.Select(UserViewModel.FromEntity).ToList();

        return ResultViewModel<IEnumerable<UserViewModel>>.Success(model);
    }
}
