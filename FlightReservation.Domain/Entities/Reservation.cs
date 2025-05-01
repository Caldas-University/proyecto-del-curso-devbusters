namespace FlightReservation.Domain.Entities;

public class Reservation
{
    public Guid Id { get; private set; }
    public Guid FlightId { get; private set; }
    public Guid SeatId { get; private set; }
    public Passenger Passenger { get; private set; }
    public DateTime ReservedAt { get; private set; }

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
