namespace EventManagement.Application.DTO;

public class CreateRequestActivityDTO
{
    public string name { get; set; } = null!;
    public string type { get; set; } = null!;
    public DateTime date { get; set; }
    public float duration { get; set; }
    public string description { get; set; } = null!;
    public string location { get; set; } = null!;
    public Guid eventId { get; set; }  // lo incluimos si la actividad se enlaza a un evento
}

public class CreateResponseActivityDTO
{
    public Guid id { get; set; }
    public string name { get; set; } = null!;
    public string type { get; set; } = null!;
    public DateTime date { get; set; }
    public float duration { get; set; }
    public string description { get; set; } = null!;
    public string location { get; set; } = null!;
}


public class UpdateRequestActivityDTO
{
    public string name { get; set; } = null!;
    public string type { get; set; } = null!;
    public DateTime date { get; set; }
    public float duration { get; set; }
    public string description { get; set; } = null!;
    public string location { get; set; } = null!;
}
