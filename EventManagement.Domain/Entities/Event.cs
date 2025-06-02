namespace EventManagement.Domain.Entities;

public class Event
{
    public Guid id { get; set; }
    public string name { get; set; }
    public string description { get;  set; }
    public DateTime startDate { get;  set; }
    public DateTime endDate { get;  set; }
    public string location { get;  set; }
    public string type { get;  set; }
    public string status { get;  set; }
    public List<Activity> Activities { get; private set; } = new();
    public List<EventReport> Reports { get; private set; } = new();
    public List<User> Users { get; private set; } = new();

    public Event(string name, string description, DateTime startDate, DateTime endDate, string location, string type, string status)
    {
        id = Guid.NewGuid();
        this.name = name ?? throw new ArgumentNullException(nameof(name));
        this.description = description ?? throw new ArgumentNullException(nameof(description));
        this.startDate = startDate;
        this.endDate = endDate;
        this.location = location ?? throw new ArgumentNullException(nameof(location));
        this.type = type ?? throw new ArgumentNullException(nameof(type));
        this.status = status ?? throw new ArgumentNullException(nameof(status));
    }
}
