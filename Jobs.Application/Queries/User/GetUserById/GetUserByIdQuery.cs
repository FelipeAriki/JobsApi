using Jobs.Application.ViewModel;
using MediatR;

namespace Jobs.Application.Queries.User.GetUserById;

public class GetUserByIdQuery : IRequest<ResultViewModel<UserViewModel>>
{
    public int Id { get; set; }

    public GetUserByIdQuery(int id)
    {
        Id = id;
    }
}
