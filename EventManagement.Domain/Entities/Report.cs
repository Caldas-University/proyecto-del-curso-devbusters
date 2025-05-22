namespace EventManagement.Domain.Entities;

public class Report
{
    public Guid id { get; private set; }
    public DateTime generatedAt { get; private set; }
    public string filters { get; private set; }

    public Report(Guid id, DateTime generatedAt, string filters)
    {
        this.id = id;
        this.generatedAt = generatedAt;
        this.filters = filters;
    }

}
