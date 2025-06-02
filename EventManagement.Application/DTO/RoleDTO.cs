namespace EventManagement.Application.DTO;

public class CreateRequestRoleDTO
{
    public Guid id { get; private set; }
    public string name { get; set; } = null!;
}

public class CreateResponseRoleDTO
{
    public Guid id { get; private set; }
    public string name { get; set; } = null!;
}