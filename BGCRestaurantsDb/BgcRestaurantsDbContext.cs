using System;
using System.Collections.Generic;
using BGCRestaurants.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BGCRestaurants.Db
{
	public class BgcRestaurantsDbContext : IdentityDbContext<User>
	{
		public DbSet<Reservation> Reservations { get; set; }
		public DbSet<Restaurant> Restaurants { get; set; }

		public BgcRestaurantsDbContext(DbContextOptions<BgcRestaurantsDbContext> options)
			:base(options)
		{
			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Restaurant>().HasMany(x=>x.Reservations).WithOne(x => x.Restaurant);
			modelBuilder.Entity<Restaurant>().HasData(new List<Restaurant>
			{
				new() { Name = "ABC", OpeningTime = new TimeSpan(15, 00, 00), ClosingTime = new TimeSpan(23, 0, 0), SmallTables = 2, MediumTables = 2, LargeTables = 1},
				new() { Name = "DEF", OpeningTime = new TimeSpan(16, 00, 00), ClosingTime = new TimeSpan(22, 0, 0), SmallTables = 2, MediumTables = 3, LargeTables = 2},
				new() { Name = "GHI", OpeningTime = new TimeSpan(17, 00, 00), ClosingTime = new TimeSpan(21, 0, 0), SmallTables = 1, MediumTables = 2, LargeTables = 1}
			});

			modelBuilder.Entity<Reservation>().HasOne(x => x.Restaurant).WithMany(x => x.Reservations).HasForeignKey(x => x.RestaurantName);
			modelBuilder.Entity<Reservation>().HasData(new List<Reservation>
			{
				new() {Id = 1, UserName = "aaa@example.com", RestaurantName = "ABC", Date = new DateTime(2020, 07, 01, 17, 00, 00), Time = "17:00 PM", NumberOfPeople = 3, Valid = true},
				new() {Id = 2, UserName = "bbb@example.com", RestaurantName = "ABC", Date = new DateTime(2020, 07, 01, 17, 00, 00), Time = "17:00 PM", NumberOfPeople = 4, Valid = true},
				new() {Id = 3, UserName = "ccc@example.com", RestaurantName = "ABC", Date = new DateTime(2020, 07, 01, 17, 00, 00), Time = "17:00 PM", NumberOfPeople = 4, Valid = false},
				new() {Id = 4, UserName = "ddd@example.com", RestaurantName = "ABC", Date = new DateTime(2020, 07, 01, 18, 00, 00), Time = "18:00 PM", NumberOfPeople = 2, Valid = true},
				new() {Id = 5, UserName = "eee@example.com", RestaurantName = "ABC", Date = new DateTime(2020, 07, 01, 18, 00, 00), Time = "18:00 PM", NumberOfPeople = 2, Valid = true},
				new() {Id = 6, UserName = "fff@example.com", RestaurantName = "ABC", Date = new DateTime(2020, 07, 01, 18, 00, 00), Time = "18:00 PM", NumberOfPeople = 2, Valid = false},
				new() {Id = 7, UserName = "ggg@example.com", RestaurantName = "ABC", Date = new DateTime(2020, 07, 01, 19, 00, 00), Time = "19:00 PM", NumberOfPeople = 1, Valid = true},
				
				new() {Id = 8, UserName = "hhh@example.com", RestaurantName = "DEF", Date = new DateTime(2020, 07, 01, 18, 00, 00), Time = "18:00 PM", NumberOfPeople = 6, Valid = true},
				new() {Id = 9, UserName = "iii@example.com", RestaurantName = "DEF", Date = new DateTime(2020, 07, 01, 18, 00, 00), Time = "18:00 PM", NumberOfPeople = 7, Valid = true},
				new() {Id = 10, UserName = "jjj@example.com", RestaurantName = "DEF", Date = new DateTime(2020, 07, 01, 18, 00, 00),Time = "18:00 PM", NumberOfPeople = 8, Valid = false},

				new() {Id = 11, UserName = "kkk@example.com", RestaurantName = "GHI", Date = new DateTime(2020, 07, 01, 16, 00, 00), Time = "16:00 PM", NumberOfPeople = 3, Valid = false},
				new() {Id = 12, UserName = "lll@example.com", RestaurantName = "GHI", Date = new DateTime(2020, 07, 01, 17, 00, 00), Time = "17:00 PM", NumberOfPeople = 3, Valid = true},
				new() {Id = 13, UserName = "mmm@example.com", RestaurantName = "GHI", Date = new DateTime(2020, 07, 01, 22, 00, 00), Time = "22:00 PM", NumberOfPeople = 3, Valid = false}
			});
		}
	}
}
