using System;
using BGCRestaurants.Entities;

namespace BGRestaurants.Domain.Dtos
{
	public class NewReservationDto
	{
		public int ReservationId { get; set; }
		public int RestaurantId { get; set; }
		public string RestaurantName { get; set; }
		public int NoOfPeople { get; set; }
		public DateTime DateTime { get; set; }
		public TableType TableType => ReservationManager.TableTypeFor(NoOfPeople);
	}
}
