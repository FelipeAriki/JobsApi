using Jobs.Application.ViewModel;
using Jobs.Core.Repositories;
using MediatR;

namespace Jobs.Application.Queries.GetJobById;
public class GetJobByIdQueryHandler : IRequestHandler<GetJobByIdQuery, ResultViewModel<JobViewModel>>
{
    private readonly IJobRepository _repository;

    public GetJobByIdQueryHandler(IJobRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<JobViewModel>> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
    {
        var job = await _repository.GetJobByIdAsync(request.Id);
        if (job == null) return ResultViewModel<JobViewModel>.Error("Oops...emprego não cadastrado.");

        return ResultViewModel<JobViewModel>.Success(JobViewModel.FromEntity(job));
    }
}
