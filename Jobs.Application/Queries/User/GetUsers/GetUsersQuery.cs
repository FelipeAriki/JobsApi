using Jobs.Application.ViewModel;
using MediatR;

namespace Jobs.Application.Queries.User.GetUsers;

public class GetUsersQuery : IRequest<ResultViewModel<IEnumerable<UserViewModel>>>
{
}
