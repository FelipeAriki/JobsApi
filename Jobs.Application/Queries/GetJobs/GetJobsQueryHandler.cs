using Jobs.Application.Queries.GetProjects;
using Jobs.Application.ViewModel;
using Jobs.Core.Entities;
using Jobs.Core.Repositories;
using MediatR;

namespace Jobs.Application.Queries.GetJobs;

public class GetJobsQueryHandler : IRequestHandler<GetJobsQuery, ResultViewModel<IEnumerable<JobViewModel>>>
{
    private readonly IJobRepository _repository;

    public GetJobsQueryHandler(IJobRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<IEnumerable<JobViewModel>>> Handle(GetJobsQuery request, CancellationToken cancellationToken)
    {
        var jobs = await _repository.GetJobsAsync();
        return new ResultViewModel<IEnumerable<JobViewModel>>(jobs.Select(JobViewModel.FromEntity).ToList());
    }
}
