using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Jobs.Infrastructure.Persistence;

public class JobsDbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public JobsDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("JobCs");
    }

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}
