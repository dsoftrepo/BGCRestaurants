using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BGRestaurants.Domain.Dtos;

namespace BGRestaurants.Domain
{
	public interface IReservationManager
	{
		int Reserve(NewReservationDto reservation, string userName);
		Task<IEnumerable<NewReservationDto>> GetReservations(string restaurantName, DateTime date);
		IEnumerable<NewReservationDto> GetPossibleReservations(string restaurantName, DateTime time);
		bool IsReservationPossible(NewReservationDto newReservationDto);
		(bool, string) ValidateReservationRequest(NewReservationDto newReservationDto);
	}
}
