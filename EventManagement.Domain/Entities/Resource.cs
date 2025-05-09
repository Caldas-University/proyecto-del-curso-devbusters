namespace EventManagement.Domain.Entities;

public class Resource
{
    public Guid id { get; private set; }
    public string type { get; private set; }
    public string description { get; private set; }
    public int stock { get; private set; }
    public bool isAvailable { get; private set; }
}
