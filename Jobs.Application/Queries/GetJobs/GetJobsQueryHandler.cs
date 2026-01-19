using Jobs.Application.Queries.GetProjects;
using Jobs.Application.ViewModel;
using Jobs.Core.Entities;
using Jobs.Core.Repositories;
using MediatR;

namespace Jobs.Application.Queries.GetJobs;

public class GetJobsQueryHandler : IRequestHandler<GetJobsQuery, ResultViewModel<IEnumerable<Job>>>
{
    private readonly IJobRepository _repository;

    public GetJobsQueryHandler(IJobRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<IEnumerable<Job>>> Handle(GetJobsQuery request, CancellationToken cancellationToken)
    {
        var jobs = await _repository.GetJobsAsync();
        return new ResultViewModel<IEnumerable<Job>>(jobs);
    }
}
