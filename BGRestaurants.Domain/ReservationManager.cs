using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BGCRestaurants.Db;
using BGCRestaurants.Entities;
using BGRestaurants.Domain.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BGRestaurants.Domain
{
	public class ReservationManager: IReservationManager
	{
		private readonly BgcRestaurantsDbContext _dbContext;
		private readonly ICache<Restaurant> _restaurantsCache;
		private readonly ICache<IEnumerable<NewReservationDto>> _freeReservationsCache;

		public ReservationManager(
			BgcRestaurantsDbContext dbContext,
			ICache<Restaurant> restaurantCache,
			ICache<IEnumerable<NewReservationDto>> freeReservationsCache)
		{
			_dbContext = dbContext;
			_restaurantsCache = restaurantCache;
			_freeReservationsCache = freeReservationsCache;
		}

		public int Reserve(NewReservationDto reservationDto, string userName)
		{
			var reservation = new Reservation
			{
				RestaurantName = reservationDto.RestaurantName,
				NumberOfPeople = reservationDto.NoOfPeople,
				Date = reservationDto.DateTime,
				Time = reservationDto.DateTime.ToString("HH:mm tt"),
				Valid = true
			};

			_dbContext.Reservations.Add(reservation);
			_dbContext.SaveChanges();

			var key = $"{reservation.RestaurantName}_{reservation.Date:yy-MM-dd}";
			IEnumerable<NewReservationDto> current = _freeReservationsCache.Get(key);
			_freeReservationsCache.Update(key, () => RemoveCurrentReservations(current, new []{ reservationDto }));

			return reservation.Id;
		}

		public async Task<IEnumerable<NewReservationDto>> GetReservations(string restaurantName, DateTime date)
		{
			Restaurant restaurant = GetRestaurant(restaurantName);
			Reservation[] reservations = await _dbContext.Reservations
				.Where(x => x.RestaurantName == restaurant.Name && x.Valid && x.Date.Date == date.Date)
				.ToArrayAsync();

			return reservations.Select(x => new NewReservationDto { RestaurantName = restaurantName, NoOfPeople = x.NumberOfPeople, DateTime = x.Date });
		}

		public IEnumerable<NewReservationDto> GetPossibleReservations(string restaurantName, DateTime time)
		{
			return _freeReservationsCache.GetOrCreate($"{restaurantName}_{time:yy-MM-dd}", () => ReservationsList(restaurantName, time).ToList());
		}

		private IEnumerable<NewReservationDto> ReservationsList(string restaurantName, DateTime dateTime)
		{
			IEnumerable<NewReservationDto> Tables(int tableSize, int tablesCount, DateTime startTime)
			{
				return Enumerable.Repeat(new NewReservationDto
				{
					RestaurantName = restaurantName,
					NoOfPeople = tableSize,
					DateTime = startTime,
				}, tablesCount);
			}

			Restaurant restaurant = GetRestaurant(restaurantName);

			int hours = restaurant.ClosingTime.Hours - restaurant.OpeningTime.Hours;
			var possibleReservations = new List<NewReservationDto>();
			for (var i = 0; i < hours; i++)
			{
				var timeSlot = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, restaurant.OpeningTime.Hours+i, 0, 0);
				possibleReservations.AddRange(Tables(2, restaurant.SmallTables, timeSlot));
				possibleReservations.AddRange(Tables(4, restaurant.MediumTables, timeSlot));
				possibleReservations.AddRange(Tables(8, restaurant.LargeTables, timeSlot));
			}

			IEnumerable<NewReservationDto> currentReservations = GetReservations(restaurantName, dateTime).Result;
			return RemoveCurrentReservations(possibleReservations, currentReservations);
		}

		private static IEnumerable<NewReservationDto> RemoveCurrentReservations(IEnumerable<NewReservationDto> allPossible, IEnumerable<NewReservationDto> booked)
		{
			List<NewReservationDto> toRemove = booked.ToList();

			foreach (NewReservationDto possible in allPossible)
			{
				int ind = toRemove.FindIndex(x => x.TableType == possible.TableType && x.DateTime == possible.DateTime);
				if (ind >= 0)
				{
					toRemove.RemoveAt(ind);
					continue;
				}

				yield return possible;
			}
		}

		public bool IsReservationPossible(NewReservationDto newReservationDto)
		{
			IEnumerable<NewReservationDto> possibleReservations = GetPossibleReservations(newReservationDto.RestaurantName, newReservationDto.DateTime);
			return possibleReservations.Any(x => x.TableType == newReservationDto.TableType && x.DateTime == newReservationDto.DateTime);
		}

		public (bool, string) ValidateReservationRequest(NewReservationDto newReservationDto)
		{
			Restaurant restaurant = GetRestaurant(newReservationDto.RestaurantName);

			if(newReservationDto.DateTime.TimeOfDay < restaurant.OpeningTime || newReservationDto.DateTime.TimeOfDay > restaurant.ClosingTime)
				return (false, "Restaurant is closed at requested time");

			if(newReservationDto.NoOfPeople > 8)
				return (false, "Max table size is 8");

			if(newReservationDto.DateTime.TimeOfDay.Minutes > 0)
				return (false, "Booking is allowed only for full hour");

			return (true, string.Empty);
		}

		private Restaurant GetRestaurant(string restaurantName) => 
			_restaurantsCache.GetOrCreate(restaurantName, () => _dbContext.Restaurants.SingleOrDefault(x => x.Name == restaurantName));

		public static TableType TableTypeFor(int people)
		{
			return people switch
			{
				>= 5 => TableType.Large,
				>= 3 => TableType.Medium,
				_ => TableType.Small
			};
		}
	}
}
