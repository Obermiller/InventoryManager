using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using InventoryManager.API.Identity.Models;
using InventoryManager.Logic.Users.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InventoryManager.API.Identity.Controllers;

[ApiController]
[AllowAnonymous]
[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[Produces("application/json")]
public class IdentityController : ControllerBase
{
	private readonly IConfiguration _configuration;
	private readonly IUserLogic _userLogic;

	public IdentityController(IConfiguration configuration, IUserLogic userLogic)
	{
		_configuration = configuration;
		_userLogic = userLogic;
	}
		
	[HttpPost("Token")]
	public IActionResult GenerateToken([FromBody] TokenGenerationRequest request)
	{
		var tokenHandler = new JwtSecurityTokenHandler();
		var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]!);

		var claims = new List<Claim>
		{
			new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			new(JwtRegisteredClaimNames.Sub, request.Email),
			new(JwtRegisteredClaimNames.Email, request.Email),
			new("userid", Guid.NewGuid().ToString())
		};

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Audience = _configuration["JwtSettings:Audience"],
			Issuer = _configuration["JwtSettings:Issuer"],
			Subject = new ClaimsIdentity(claims),
			Expires = DateTime.UtcNow.Add(TimeSpan.FromMinutes(20)),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
		};

		var token = tokenHandler.CreateToken(tokenDescriptor);

		var jwt = tokenHandler.WriteToken(token);
		return Ok(jwt);
	}
}