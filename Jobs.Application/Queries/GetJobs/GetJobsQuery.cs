using Jobs.Application.ViewModel;
using Jobs.Core.Entities;
using MediatR;

namespace Jobs.Application.Queries.GetProjects;

public class GetJobsQuery : IRequest<ResultViewModel<IEnumerable<JobViewModel>>>
{
}
