namespace EventManagement.Application.DTO;

public class RoleUserRequestDTO
{
    public Guid id { get; private set; }
    public Guid idRole { get; set; }
    public Guid idUser { get; set; }
}

public class RoleUserResponseDTO
{
    public Guid id { get; private set; }
    public Guid idRole { get; set; }
    public Guid idUser { get; set; }
}