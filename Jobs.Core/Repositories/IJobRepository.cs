using Jobs.Core.Entities;

namespace Jobs.Core.Repositories;

public interface IJobRepository
{
    Task<IEnumerable<Job>> GetJobsAsync();
    Task<Job?> GetJobByIdAsync(int id);
    Task<int> CreateJobAsync(Job job);
    Task UpdateJobAsync(Job job);
    Task DeleteJobAsync(int id);
}
