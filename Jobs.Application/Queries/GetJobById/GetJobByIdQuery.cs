using Jobs.Application.ViewModel;
using Jobs.Core.Entities;
using MediatR;

namespace Jobs.Application.Queries.GetJobById;

public class GetJobByIdQuery : IRequest<ResultViewModel<Job>>
{
    public int Id { get; set; }

    public GetJobByIdQuery(int id)
    {
        Id = id;
    }
}
