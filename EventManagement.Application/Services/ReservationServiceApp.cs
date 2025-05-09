namespace FlightReservation.Application.Services;

using FlightReservation.Application.Contracts.Services;
using FlightReservation.Domain.Entities;
using FlightReservation.Domain.Repositories;

public class ReservationServiceApp : IReservationServiceApp
{
    private readonly IFlightRepository _flightRepository;
    private readonly IReservationRepository _reservationRepository;

    public ReservationServiceApp(IFlightRepository flightRepository, IReservationRepository reservationRepository)
    {
        _flightRepository = flightRepository ?? throw new ArgumentNullException(nameof(flightRepository));
        _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
    }

    public async Task<Guid> ReserveFlightAsync(Guid flightId, string seatNumber, string documentNumber, string fullName)
    {
        var flight = await _flightRepository.GetFlightAsync(flightId)
            ?? throw new Exception("Flight not found.");

        var cleanedSeatNumber = seatNumber?.Trim().ToUpperInvariant();

        var seat = flight.Seats
            .FirstOrDefault(s => !s.IsReserved && s.SeatNumber.Equals(cleanedSeatNumber, StringComparison.InvariantCultureIgnoreCase))
            ?? throw new Exception("No available seat matching the requested seat number.");

        seat.Reserve();

        var passenger = new Passenger(documentNumber, fullName);
        var reservation = new Reservation(flight.Id, seat.Id, passenger);

        await _reservationRepository.AddAsync(reservation);

        return reservation.Id;
    }

}
