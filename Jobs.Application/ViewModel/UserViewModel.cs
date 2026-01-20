using Jobs.Core.Entities;

namespace Jobs.Application.ViewModel;

public class UserViewModel
{
    public int Id { get; private set; }
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public bool Active { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public UserViewModel(int id, string fullName, string email, DateTime birthDate, bool active, DateTime createdAt)
    {
        Id = id;
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
        Active = active;
        CreatedAt = createdAt;
    }

    public static UserViewModel FromEntity(User user)
    {
        return new UserViewModel(user.Id, user.FullName, user.Email, user.BirthDate, user.Active, user.CreatedAt);
    }
}
