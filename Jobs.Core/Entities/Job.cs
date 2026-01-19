namespace Jobs.Core.Entities;

public class Job
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Location { get; private set; }
    public decimal Salary { get; private set; }

    public Job(int id, string title, string description, string location, decimal salary)
    {
        Id = id;
        Title = title;
        Description = description;
        Location = location;
        Salary = salary;
    }
    public Job(string title, string description, string location, decimal salary)
    {
        Title = title;
        Description = description;
        Location = location;
        Salary = salary;
    }
}
