using InventoryManager.Core.Constants.Identity;
using InventoryManager.Logic.Identity.Contracts;
using InventoryManager.Logic.Url.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.API.Areas.Utilities;

public class UtilitiesController : ControllerBase
{
	private readonly ITokenLogic _tokenLogic;
	private readonly IUrlLogic _urlLogic;
	
	public UtilitiesController(ITokenLogic tokenLogic, IUrlLogic urlLogic)
	{
		_tokenLogic = tokenLogic;
		_urlLogic = urlLogic;
	}
	
	//Site
	protected string GetBaseUrl() => _urlLogic.GetBaseUrl();

	//Token
	protected Guid? GetUserId()
    {
        return _tokenLogic.GetUserId(Request.Headers[IdentityConstants.Authorization]);
    }
}