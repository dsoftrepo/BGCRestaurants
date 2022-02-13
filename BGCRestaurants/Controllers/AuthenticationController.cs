using Microsoft.AspNetCore.Http;  
using Microsoft.AspNetCore.Identity;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.Extensions.Configuration;  
using Microsoft.IdentityModel.Tokens;  
using System;  
using System.Collections.Generic;  
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;  
using System.Text;  
using System.Threading.Tasks;
using BGCRestaurants.Api.Models;
using BGCRestaurants.Entities;

namespace BGCRestaurants.Api.Controllers
{
	[Route("api/[controller]")]  
    [ApiController]  
    public class AuthenticationController : ControllerBase  
    {  
        private readonly UserManager<User> _userManager;  
        private readonly IConfiguration _configuration;  
  
        public AuthenticationController(UserManager<User> userManager, IConfiguration configuration)  
        {  
            _userManager = userManager;  
            _configuration = configuration;  
        }  
  
        [HttpPost]  
        [Route("login")]  
        public async Task<IActionResult> Login(LoginModel model)  
        {  
            User user = await _userManager.FindByNameAsync(model.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
	            return Unauthorized();
            
            var authClaims = new List<Claim>  
            {  
	            new (ClaimTypes.Name, user.UserName),  
	            new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())  
            };  
  
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));  
  
            var token = new JwtSecurityToken(  
	            issuer: _configuration["JWT:ValidIssuer"],  
	            audience: _configuration["JWT:ValidAudience"],  
	            expires: DateTime.Now.AddMinutes(30), 
	            claims: authClaims,  
	            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)  
            );  
  
            return Ok(new  
            {  
	            token = new JwtSecurityTokenHandler().WriteToken(token),  
	            expiration = token.ValidTo  
            });
        }  
  
        [HttpPost]  
        [Route("register")]  
        public async Task<IActionResult> Register(RegisterModel model)  
        {  
            User userExists = await _userManager.FindByEmailAsync(model.Email);  
            if (userExists != null)  
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User already exists!" });  
  
            var user = new User
            {  
                Email = model.Email,  
                UserName = model.Email  
            };  
            
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);  
            
            return !result.Succeeded 
	            ? StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = string.Join(",", result.Errors.Select(x=>x.Description))  }) 
	            : Ok(new { Status = "Success", Message = "User created successfully!" });
        }  
    }  
}
