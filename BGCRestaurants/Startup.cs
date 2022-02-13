using System;
using System.Collections.Generic;
using System.Text;
using BGCRestaurants.Db;
using BGCRestaurants.Entities;
using BGRestaurants.Domain;
using BGRestaurants.Domain.Dtos;
using BGSRestaurants.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace BGCRestaurants.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<BgcRestaurantsDbContext>(opt =>
			{
				const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
				string path = Environment.GetFolderPath(folder);
				string dbPath = System.IO.Path.Join(path, "bgc_restaurants.db");

				opt.UseSqlite($"Data Source={dbPath}", b => b.MigrationsAssembly("BGCRestaurants.Api"));
			});

			services.AddIdentityCore<User>()
				.AddEntityFrameworkStores<BgcRestaurantsDbContext>()
				.AddDefaultTokenProviders(); 

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>  
				{  
					options.SaveToken = true;  
					options.RequireHttpsMetadata = false;  
					options.TokenValidationParameters = new TokenValidationParameters  
					{  
						ValidateIssuer = true,  
						ValidateAudience = true,  
						ValidateIssuerSigningKey = true,
						ValidAudience = Configuration["JWT:ValidAudience"],  
						ValidIssuer = Configuration["JWT:ValidIssuer"],  
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"])),
						ClockSkew = TimeSpan.Zero
					};  
				});  

			services.AddControllers();
			services.AddScoped<IReservationManager, ReservationManager>();
			services.AddSingleton<ICache<Restaurant>, InMemoryCache<Restaurant>>();
			services.AddSingleton<ICache<IEnumerable<NewReservationDto>>, InMemoryCache<IEnumerable<NewReservationDto>>>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
