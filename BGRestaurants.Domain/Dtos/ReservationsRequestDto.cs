using System;

namespace BGRestaurants.Domain.Dtos
{
	public class ReservationsRequestDto
	{
		public DateTime Date { get; set; }
		public string RestaurantName { get; set; }
	}
}
