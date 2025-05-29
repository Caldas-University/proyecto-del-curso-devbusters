namespace EventManagement.Application.DTO;

public class UserRequestDTO
{
    public Guid id { get; private set; }
    public string name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string phoneNumber { get; set; }
}

public class UserResponseDTO
{
    public Guid id { get; private set; }
    public string name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string phoneNumber { get; set; }
}