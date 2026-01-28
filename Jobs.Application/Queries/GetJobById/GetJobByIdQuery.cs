using Jobs.Application.ViewModel;
using MediatR;

namespace Jobs.Application.Queries.GetJobById;

public class GetJobByIdQuery : IRequest<ResultViewModel<JobViewModel>>
{
    public int Id { get; set; }

    public GetJobByIdQuery(int id)
    {
        Id = id;
    }
}
