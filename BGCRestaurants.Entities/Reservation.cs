using System;

namespace BGCRestaurants.Entities
{
	public class Reservation
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string RestaurantName { get; set; }
		public DateTime Date { get; set; }
		public string Time { get; set; }
		public int NumberOfPeople { get; set; }
		public bool Valid { get; set; }

		public Restaurant Restaurant { get; set; }
	}
}
