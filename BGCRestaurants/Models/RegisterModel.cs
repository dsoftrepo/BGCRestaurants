﻿using System.ComponentModel.DataAnnotations;

namespace BGCRestaurants.Api.Models
{
	public class RegisterModel  
	{  
		[EmailAddress]  
		[Required(ErrorMessage = "Email is required")]  
		public string Email { get; set; }  
  
		[Required(ErrorMessage = "Password is required")]  
		public string Password { get; set; }  
	}  
}
