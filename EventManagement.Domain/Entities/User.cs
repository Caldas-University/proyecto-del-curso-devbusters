namespace EventManagement.Domain.Entities;

public enum Role {
    ORGANIZER,
    PARTICIPANT,
    SPONSOR,
    ADMINISTRATOR,
    SUPPLIER,
    SPEAKER
}

public class User
{
    public Guid id { get; private set; }
    public string name { get; private set; }
    public string email { get; private set; }
    public string password { get; private set; }
    public string phoneNumber { get; private set; }
    public Role role { get; private set; }
}
