using Jobs.Application.ViewModel;
using Jobs.Core.Repositories;
using MediatR;

namespace Jobs.Application.Commands.DeleteJob;

public class DeleteJobCommandHandler : IRequestHandler<DeleteJobCommand, ResultViewModel>
{
    private readonly IJobRepository _repository;

    public DeleteJobCommandHandler(IJobRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
    {
        var job = await _repository.GetJobByIdAsync(request.Id);
        if (job == null) return ResultViewModel.Error("Oops...emprego não encontrado.");

        await _repository.DeleteJobAsync(request.Id);
        return ResultViewModel.Success();
    }
}
