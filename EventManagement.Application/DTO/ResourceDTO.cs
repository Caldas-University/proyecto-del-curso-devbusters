namespace EventManagement.Application.DTO;

public class CreateRequestResourceDTO
{
    public Guid id { get; private set; } 
    public string name { get; set; } = null!;
    public string type { get; set; } = null!;
    public string description { get; set; } = null!;
    public int stock { get; set; }
    public bool isAvailable { get; set; }
}


public class CreateResponseResourceDTO
{
    public Guid id { get; private set; }
    public string name { get; set; } = null!;
    public string type { get; set; } = null!;
    public string description { get; set; } = null!;
    public int stock { get; set; }
    public bool IsAvailable { get; set; }
}

