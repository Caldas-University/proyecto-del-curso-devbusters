namespace EventManagement.Domain.Entities;

public class HistoryEvent
{
    public Guid id { get; set; }
    public Guid idEvent { get; set; }
    public string description { get; set; }
    public DateTime date { get; set; }

    public HistoryEvent(Guid idEvent, string description, DateTime date)
    {
        this.idEvent = idEvent;
        this.description = description;
        this.date = date;
    }
}
