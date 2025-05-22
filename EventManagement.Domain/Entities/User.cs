namespace EventManagement.Domain.Entities;

public class User
{
    public Guid id { get; private set; }
    public string name { get; private set; }
    public string email { get; private set; }
    public string password { get; private set; }
    public string phoneNumber { get; private set; }

    public User(Guid id, string name, string email, string password, string phoneNumber)
    {
        this.id = id;
        this.name = name;
        this.email = email;
        this.password = password;
        this.phoneNumber = phoneNumber;
    }
}
