namespace FlightReservation.Domain.Entities;

public class Flight
{
    public Guid Id { get; private set; }
    public string Origin { get; private set; }
    public string Destination { get; private set; }
    public DateTime DepartureDate { get; private set; }
    public List<Seat> Seats { get; private set; } = new();

    public Flight(string origin, string destination, DateTime departureDate)
    {
        Id = Guid.NewGuid();
        Origin = origin;
        Destination = destination;
        DepartureDate = departureDate;
    }
        public Seat? FindAvailableSeat(string seatPreference)
    {
        // Logic to find an available seat based on the preference
        return Seats.FirstOrDefault(seat => seat.Preference == seatPreference && !seat.IsReserved);
    }
}
