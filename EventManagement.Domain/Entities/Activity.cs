namespace EventManagement.Domain.Entities;

public class Activity
{
    public Guid id { get; private set; }
    public string type { get; private set; }
    public DateTime date { get; private set; }
    public float duration { get; private set; }
    public string description { get; private set; } 

    private Passenger()
    {
        DocumentNumber = string.Empty;
        FullName = string.Empty;
    } 

    public Passenger(string documentNumber, string fullName)
    {
        Id = Guid.NewGuid();
        DocumentNumber = documentNumber ?? throw new ArgumentNullException(nameof(documentNumber));
        FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
    }
}
