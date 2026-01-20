using Dapper;
using Jobs.Core.Entities;
using Jobs.Core.Repositories;

namespace Jobs.Infrastructure.Persistence.Repositories;

public class JobRepository : IJobRepository
{
    private readonly JobsDbContext _dbContext;

    public JobRepository(JobsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Job>> GetJobsAsync()
    {
        using var connection = _dbContext.CreateConnection();
        var sql = "SELECT id, title, description, location, salary FROM Job(NOLOCK)";
        return await connection.QueryAsync<Job>(sql);
    }

    public async Task<Job?> GetJobByIdAsync(int id)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = "SELECT id, title, description, location, salary FROM Job(NOLOCK) WHERE id = @Id";
        return await connection.QueryFirstOrDefaultAsync<Job?>(sql, new { Id = id });
    }

    public async Task<int> CreateJobAsync(Job job)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = @"INSERT INTO Job(title, description, location, salary)
                    OUTPUT INSERTED.Id
                    VALUES(@title, @description, @location, @salary)";
        return await connection.QuerySingleAsync<int>(sql, job);
    }

    public async Task UpdateJobAsync(Job job)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = @"UPDATE Job SET
                        title = @Title,
                        description = @Description,
                        location = @Location,
                        salary = @Salary
                    WHERE id = @Id";
        await connection.ExecuteAsync(sql, job);
    }

    public async Task DeleteJobAsync(int id)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = "DELETE FROM Job WHERE id = @Id";
        await connection.ExecuteAsync(sql, new {Id = id});
    }
}
