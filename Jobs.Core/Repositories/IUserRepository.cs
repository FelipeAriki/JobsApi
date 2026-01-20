using Jobs.Core.Entities;

namespace Jobs.Core.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<User?> GetUserByEmailPasswordAsync(string email, string password);
    Task<User?> GetUserByEmailAsync(string email);
    Task<int> CreateUserAsync(User project);
    Task UpdateUserAsync(User project);
    Task DeleteUserAsync(int id);
}
