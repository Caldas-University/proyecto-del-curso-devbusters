namespace FlightReservation.Infrastructure.Persistence;

using FlightReservation.Domain.Entities;

public static class SeedData
{
    public static void Initialize(FlightReservationDbContext context)
    {
        if (context.Flights.Any())
        {
            
            return;
        }

        // Crear vuelo
        var flight = new Flight(
            origin: "Bogota",
            destination: "Medellin",
            departureDate: DateTime.UtcNow.AddDays(1)
        );

        // Crear asientos
        for (int i = 1; i <= 10; i++)
        {
            var seatNumber = $"A{i:D2}"; // A01, A02, etc.
            var preference = (i % 2 == 0) ? "Window" : "Aisle"; // Alternar preferencias
            flight.Seats.Add(new Seat(seatNumber, preference));
        }

        context.Flights.Add(flight);
        context.SaveChanges();
    }
}
