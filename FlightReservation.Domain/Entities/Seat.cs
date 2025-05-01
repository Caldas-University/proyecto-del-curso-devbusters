public class Seat
{
    public Guid Id { get; private set; }
    public string SeatNumber { get; private set; }
    public bool IsReserved { get; private set; }
    public string Preference { get; private set; }

    private Seat() { } // Constructor protegido para EF Core

    public Seat(string seatNumber, string preference)
    {
        Id = Guid.NewGuid();
        SeatNumber = seatNumber ?? throw new ArgumentNullException(nameof(seatNumber));
        Preference = preference ?? throw new ArgumentNullException(nameof(preference));
        IsReserved = false;
    }

    public void Reserve()
    {
        if (IsReserved) throw new InvalidOperationException("Seat already reserved.");
        IsReserved = true;
    }
}
