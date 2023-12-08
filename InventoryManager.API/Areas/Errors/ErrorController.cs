using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.API.Areas.Errors;

[ApiController]
[Route("[controller]")]
public class ErrorController : ControllerBase
{
	private readonly ILogger<ErrorController> _logger;
	
	public ErrorController(ILogger<ErrorController> logger) => _logger = logger ?? throw new ArgumentNullException(nameof(logger));
	
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]
	public ActionResult<string> Index()
	{
		_logger.LogError("An error occurred"); //TODO
		
		return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
	}
}