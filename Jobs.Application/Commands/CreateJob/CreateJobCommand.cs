using Jobs.Application.ViewModel;
using Jobs.Core.Entities;
using MediatR;

namespace Jobs.Application.Commands.CreateJob;

public class CreateJobCommand : IRequest<ResultViewModel<int>>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public decimal Salary { get; set; }

    public Job ToEntity() => new(Title, Description, Location, Salary);
}
