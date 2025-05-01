namespace FlightReservation.Domain.Entities;

public class Passenger
{
    public Guid Id { get; private set; }
    public string DocumentNumber { get; private set; }
    public string FullName { get; private set; }

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
