using Jobs.Application.ViewModel;
using Jobs.Core.Repositories;
using MediatR;

namespace Jobs.Application.Commands.CreateJob;

public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, ResultViewModel<int>>
{
    private readonly IJobRepository _repository;

    public CreateJobCommandHandler(IJobRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<int>> Handle(CreateJobCommand request, CancellationToken cancellationToken)
    {
        var job = request.ToEntity();
        var idJob = await _repository.CreateJobAsync(job);
        return ResultViewModel<int>.Success(idJob);
    }
}
