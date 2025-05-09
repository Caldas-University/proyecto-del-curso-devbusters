namespace EventManagement.Domain.Entities;

public class Event
{
    public Guid id { get; private set; }
    public string name { get; private set; }
    public string description { get; private set; }
    public DateTime startDate { get; private set; }
    public DateTime endDate { get; private set; }
    public string location { get; private set; }
    public string type { get; private set; }
    public string status { get; private set; }
    
    // Falta definir actividades y algunos atributos más

    private Reservation()
    {
        Passenger = null!;
    }

    public Reservation(Guid flightId, Guid seatId, Passenger passenger)
    {
        Id = Guid.NewGuid();
        FlightId = flightId;
        SeatId = seatId;
        Passenger = passenger ?? throw new ArgumentNullException(nameof(passenger));
        ReservedAt = DateTime.UtcNow;
    }
}
