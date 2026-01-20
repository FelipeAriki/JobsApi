using Jobs.Application.ViewModel;
using MediatR;

namespace Jobs.Application.Commands.User.UpdateUser;

public class UpdateUserCommand : IRequest<ResultViewModel>
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public bool Active { get; set; }
}
