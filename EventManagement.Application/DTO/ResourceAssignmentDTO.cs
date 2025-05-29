namespace EventManagement.Application.DTO;

public class CreateRequestResourceAssignmentDTO
{
    public Guid activityId { get; set; }
    public Guid resourceId { get; set; }
    public int quantity { get; set; }
    public DateTime assignedFrom { get; set; }
    public DateTime assignedTo { get; set; }
}

public class CreateResponseResourceAssignmentDTO
{
    public Guid id { get; set; }
    public Guid activityId { get; set; }
    public Guid resourceId { get; set; }
    public int quantity { get; set; }
    public DateTime assignedFrom { get; set; }
    public DateTime assignedTo { get; set; }
}
