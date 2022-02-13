using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BGCRestaurants.Entities
{
	public class Restaurant
	{
		[Key]
		public string Name { get; set; }
		public TimeSpan OpeningTime { get; set; }
		public TimeSpan ClosingTime { get; set; }
		public int SmallTables { get; set; }
		public int MediumTables { get; set; }
		public int LargeTables { get; set; }
		public List<Reservation> Reservations { get; set; }
	}
}
