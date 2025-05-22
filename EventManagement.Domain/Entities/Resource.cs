namespace EventManagement.Domain.Entities;

public class Resource
{
    public Guid id { get; private set; }
    public string name { get; private set; }
    public string type { get; private set; }
    public string description { get; private set; }
    public int stock { get; private set; }
    public bool isAvailable { get; private set; }

    public Resource(Guid id, string name, string type, string description, int stock, bool isAvailable)
    {
        this.id = id;
        this.name = name;
        this.type = type;
        this.description = description;
        this.stock = stock;
        this.isAvailable = isAvailable;
    }
}
