using API.Models;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

[ApiController, Route("[controller]")]
public class RegisterCardController : ControllerBase
{
	private readonly ILogger<RegisterCardController> _logger;

	public RegisterCardController(ILogger<RegisterCardController> logger)
	{
		_logger = logger;
	}

	[Route("")]
	public void Post([FromBody] CardModel card, [FromHeader]Guid customerid)
	{
	}
}