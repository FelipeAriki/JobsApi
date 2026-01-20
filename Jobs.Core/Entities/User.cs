namespace Jobs.Core.Entities;

public class User
{
    public int Id { get; set; }
    public string? FullName { get; private set; }
    public string? Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public DateTime CreatedAt { get; set; }
    public bool Active { get; private set; }
    public string Password { get; private set; }
    public string Role { get; private set; }

    protected User() { }

    public User(string fullName, string email, DateTime birthDate, string password, string role)
    {
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
        Active = true;
        Password = password;
        Role = role;
    }

    public void Update(string name, string email, DateTime birthDate, bool active)
    {
        FullName = name;
        Email = email;
        BirthDate = birthDate;
        Active = active;
    }

    public void UpdatePassword(string password)
    {
        Password = password;
    }
}
