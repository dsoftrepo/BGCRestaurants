using Microsoft.EntityFrameworkCore;

namespace BGCRestaurants.Db
{
	public static class DbInitializer
	{
		public static void Initialize(BgcRestaurantsDbContext context)
		{
			context.Database.Migrate();
		}
	}
}
