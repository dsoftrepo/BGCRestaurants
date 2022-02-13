using System.Collections.Generic;
using System.Threading.Tasks;
using BGRestaurants.Domain;
using BGRestaurants.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BGCRestaurants.Api.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class ReservationsController : ControllerBase
	{
		private readonly IReservationManager _reservationManager;

		public ReservationsController(IReservationManager reservationManager)
		{
			_reservationManager = reservationManager;
		}

		[HttpPost]
		public async Task<IActionResult> GetReservations(ReservationsRequestDto dto)
		{
			IEnumerable<NewReservationDto> reservations =  await _reservationManager.GetReservations(dto.RestaurantName, dto.Date);
			return Ok(reservations);
		}

		[HttpPost("free")]
		public IActionResult GetPossibleReservations(ReservationsRequestDto dto)
		{
			IEnumerable<NewReservationDto> reservations = _reservationManager.GetPossibleReservations(dto.RestaurantName, dto.Date);
			return Ok(reservations);
		}

		[HttpPost("book")]
		public IActionResult MakeReservation(NewReservationDto dto)
		{
			(bool valid, string message) = _reservationManager.ValidateReservationRequest(dto);
			if (!valid)
				return BadRequest(message);

			if (_reservationManager.IsReservationPossible(dto))
				dto.ReservationId = _reservationManager.Reserve(dto, User?.Identity?.Name);
			else
				return BadRequest("Reservation is not possible at the time");
			
			return Ok(dto);
		}
	}
}
