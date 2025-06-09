namespace EventManagement.Domain.Entities;

public class Activity
{
    public Guid id { get; private set; }
    public string name { get; private set; }    
    public string type { get; private set; }
    public DateTime date { get; private set; }
    public float duration { get; private set; }
    public string description { get; private set; } 

    public string location { get; private set; }

    public Guid eventId { get; private set; }


    public Activity(Guid id, string type, string name, DateTime date, float duration, string description, string location, Guid eventId)
    {
        this.id = id;
        this.type = type;
        this.name = name;
        this.date = date;
        this.duration = duration;
        this.description = description;
        this.location = location;
        this.eventId = eventId;
    }
}
