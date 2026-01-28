using Jobs.Core.Entities;

namespace Jobs.Application.ViewModel;

public class JobViewModel
{
    public int Id { get; set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Location { get; private set; }
    public decimal Salary { get; private set; }

    public JobViewModel(int id, string title, string description, string location, decimal salary)
    {
        Id = id;
        Title = title;
        Description = description;
        Location = location;
        Salary = salary;
    }

    public static JobViewModel FromEntity(Job job)
    {
        return new(job.Id, job.Title, job.Description, job.Location, job.Salary);
    }
}
