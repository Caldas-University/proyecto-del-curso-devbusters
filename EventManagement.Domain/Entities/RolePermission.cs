namespace EventManagement.Domain.Entities;

public class RolePermission
{
    public Guid id { get; private set; }
    public Guid idRole { get; private set; }
    public Guid idPermission { get; private set; }

    public RolePermission(Guid id, Guid idRole, Guid idPermission)
    {
        this.id = id;
        this.idRole = idRole;
        this.idPermission = idPermission;
    }
}