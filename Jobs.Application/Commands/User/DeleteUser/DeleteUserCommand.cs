using Jobs.Application.ViewModel;
using MediatR;

namespace Jobs.Application.Commands.User.DeleteUser;

public class DeleteUserCommand : IRequest<ResultViewModel>
{
    public int Id { get; set; }

    public DeleteUserCommand(int id)
    {
        Id = id;
    }
}
