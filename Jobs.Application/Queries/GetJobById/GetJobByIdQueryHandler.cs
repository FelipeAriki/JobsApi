using Jobs.Application.ViewModel;
using Jobs.Core.Entities;
using Jobs.Core.Repositories;
using MediatR;

namespace Jobs.Application.Queries.GetJobById;
public class GetJobByIdQueryHandler : IRequestHandler<GetJobByIdQuery, ResultViewModel<Job>>
{
    private readonly IJobRepository _repository;

    public GetJobByIdQueryHandler(IJobRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<Job>> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
    {
        var job = await _repository.GetJobByIdAsync(request.Id);
        if (job == null) return ResultViewModel<Job>.Error("Oops...emprego não cadastrado.");

        return ResultViewModel<Job>.Success(job);
    }
}
