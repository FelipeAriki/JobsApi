using Jobs.Application.ViewModel;
using Jobs.Core.Entities;
using MediatR;

namespace Jobs.Application.Commands.UpdateJob;

public class UpdateJobCommand : IRequest<ResultViewModel>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public decimal Salary { get; set; }

    public Job ToEntity() => new(Id, Title, Description, Location, Salary);
}
