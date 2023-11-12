using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers;

[ApiController, Route("[controller]")]
public class RegisterCardController(IPaymentService payment) : ControllerBase
{
	[HttpPost("[action]")] //{customerid:Guid}
	public CardModel Post([FromBody] CardModelRequest card, [FromHeader] Guid customerid) => payment.ProcessPayment(card, customerid);
}

public class CardModelRequest
{
	[Required]
	public string Number { get; set; } = string.Empty;

	[Required, StringLength(4)]
	public string CVV { get; set; } = string.Empty;
}