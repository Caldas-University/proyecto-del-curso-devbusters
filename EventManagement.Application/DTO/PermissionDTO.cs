namespace EventManagement.Application.DTO;

public class CreateRequestPermissionDTO
{
    public Guid id { get; private set; }
    public string name { get; set; } = null!;
    public string description { get; set; } = null!;
}

public class CreateResponsePermissionDTO
{
    public Guid id { get; private set; }
    public string name { get; set; } = null!;
    public string description { get; set; } = null!;
}