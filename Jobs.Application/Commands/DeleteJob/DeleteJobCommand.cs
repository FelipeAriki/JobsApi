using Jobs.Application.ViewModel;
using MediatR;

namespace Jobs.Application.Commands.DeleteJob;

public class DeleteJobCommand : IRequest<ResultViewModel>
{
    public int Id { get; set; }
}
