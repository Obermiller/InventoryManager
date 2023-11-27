using System.IdentityModel.Tokens.Jwt;
using InventoryManager.Logic.Identity.Contracts;

namespace InventoryManager.Logic.Identity;

public class TokenLogic : ITokenLogic
{
	public Guid? GetUserId(string? header)
	{
		if (header is not null)
		{
			var token = ParseToken(header);
			var claim = token.Claims.First(claim => claim.Type == "userid");

			if (claim is not null)
			{
				return Guid.Parse(claim.Value);
			}
		}
		
		return null;
	}

	private JwtSecurityToken ParseToken(string header)
	{
		var tokenHandler = new JwtSecurityTokenHandler();
		var tokenString = header.Replace("Bearer ", string.Empty);
		var token = tokenHandler.ReadJwtToken(tokenString);

		return token;
	}
}