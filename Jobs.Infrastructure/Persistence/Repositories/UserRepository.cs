using Dapper;
using Jobs.Core.Entities;
using Jobs.Core.Repositories;

namespace Jobs.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly JobsDbContext _dbContext;

    public UserRepository(JobsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        using var connection = _dbContext.CreateConnection();
        var sql = "SELECT id AS Id, full_name AS FullName, email AS Email, birth_date AS BirthDate, created_at AS CreatedAt, active AS Active, password AS Password, role AS Role FROM Users(NOLOCK)";
        return await connection.QueryAsync<User>(sql);
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = "SELECT id AS Id, full_name AS FullName, email AS Email, birth_date AS BirthDate, created_at AS CreatedAt, active AS Active, password AS Password, role AS Role FROM Users(NOLOCK) WHERE id = @Id";
        return await connection.QueryFirstOrDefaultAsync<User?>(sql, new { Id = id });
    }

    public async Task<User?> GetUserByEmailPasswordAsync(string email, string password)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = "SELECT id AS Id, full_name AS FullName, email AS Email, birth_date AS BirthDate, created_at AS CreatedAt, active AS Active, password AS Password, role AS Role FROM Users(NOLOCK) WHERE email = @Email AND password = @Password";
        return await connection.QueryFirstOrDefaultAsync<User?>(sql, new { Email = email, Password = password });
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = "SELECT id AS Id, full_name AS FullName, email AS Email, birth_date AS BirthDate, created_at AS CreatedAt, active AS Active, password AS Password, role AS Role FROM Users(NOLOCK) WHERE email = @Email";
        return await connection.QueryFirstOrDefaultAsync<User?>(sql, new { Email = email });
    }

    public async Task<int> CreateUserAsync(User user)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = @"INSERT INTO Users(full_name, email, birth_date, active, password, role)
                    OUTPUT INSERTED.Id
                    VALUES(@FullName, @Email, @BirthDate, @Active, @Password, @Role)";
        return await connection.QuerySingleAsync<int>(sql, user);
    }

    public async Task UpdateUserAsync(User user)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = @"UPDATE Users SET
                        full_name = @FullName,
                        email = @Email,
                        birth_date = @BirthDate,
                        active = @Active
                    WHERE id = @Id";
        await connection.ExecuteAsync(sql, user);
    }

    public async Task DeleteUserAsync(int id)
    {
        using var connection = _dbContext.CreateConnection();
        var sql = "DELETE FROM Users WHERE id = @Id";
        await connection.ExecuteAsync(sql, new { Id = id });
    }
}
