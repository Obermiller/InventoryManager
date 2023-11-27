using InventoryManager.Logic.Url.Contracts;
using Microsoft.Extensions.Configuration;

namespace InventoryManager.Logic.Url;

public class UrlLogic : IUrlLogic
{
	private readonly IConfiguration _config;

	public UrlLogic(IConfiguration config)
	{
		_config = config;
	}

	public string GetBaseUrl() => _config["BaseUrl"] ?? string.Empty;
}