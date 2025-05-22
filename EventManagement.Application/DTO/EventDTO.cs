namespace EventManagement.Application.DTO;

public class CreateRequestEventDTO
{
    public Guid id { get; private set; }
    public string name { get; set; } = null!;
    public string description { get;   set; } = null!;
    public DateTime startDate { get;   set; }
    public DateTime endDate { get;   set; }
    public string location { get;   set; } = null!;
    public string type { get;   set; } = null!;
    public string status { get;   set; } = null!;

}

public class CreateResponseEventDTO
{
    public Guid id { get; private set; }
    public string name { get; set; } = null!;
    public string description { get; set; } = null!;
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
    public string location { get; set; } = null!;
    public string type { get; set; } = null!;
    public string status { get; set; }= null!;

}