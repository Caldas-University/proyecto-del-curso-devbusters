using FlightReservation.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationController : ControllerBase
{
    private readonly IReservationServiceApp _reservationService;

    public ReservationController(IReservationServiceApp reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpPost]
    public async Task<IActionResult> ReserveFlight(Guid flightId, string seatPreference, string documentNumber, string fullName)
    {
        var reservationId = await _reservationService.ReserveFlightAsync(flightId, seatPreference, documentNumber, fullName);
        return Ok(new { ReservationId = reservationId });
    }
}
