namespace EventManagement.Application.DTO;

public class RolePermissionRequestDTO
{
    public Guid id { get; private set; }
    public Guid idRole { get; set; }
    public Guid idPermission { get; set; }
}

public class RolePermissionResponseDTO
{
    public Guid id { get; private set; }
    public Guid idRole { get; set; }
    public Guid idPermission { get; set; }
}