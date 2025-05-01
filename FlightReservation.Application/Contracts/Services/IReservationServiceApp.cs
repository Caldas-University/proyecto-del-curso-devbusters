namespace FlightReservation.Application.Contracts.Services;

public interface IReservationServiceApp
{
    Task<Guid> ReserveFlightAsync(Guid flightId, string seatPreference, string documentNumber, string fullName);
}
