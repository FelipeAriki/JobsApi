using Jobs.Application.ViewModel;
using Jobs.Core.Repositories;
using MediatR;

namespace Jobs.Application.Commands.UpdateJob;

public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand, ResultViewModel>
{
    private readonly IJobRepository _repository;

    public UpdateJobCommandHandler(IJobRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
    {
        var job = await _repository.GetJobByIdAsync(request.Id);
        if (job == null) return ResultViewModel.Error("Oops...emprego não encontrado.");

        await _repository.UpdateJobAsync(request.ToEntity());
        return ResultViewModel.Success();
    }
}
