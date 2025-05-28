namespace EventManagement.Domain.Entities;

public class ResourceAssignment
{
    public Guid id { get; private set; }
    public Guid idActivity { get; private set; }
    public Guid idResource { get; private set; }
    public int quantity { get; private set; }
    public DateTime assignedFrom { get; private set; }
    public DateTime assignedTo { get; private set; }

    public ResourceAssignment(Guid id, Guid idActivity, Guid idResource, int quantity, DateTime assignedFrom, DateTime assignedTo)
    {
        this.id = id;
        this.idActivity = idActivity;
        this.idResource = idResource;
        this.quantity = quantity;
        this.assignedFrom = assignedFrom;
        this.assignedTo = assignedTo;
    }
}