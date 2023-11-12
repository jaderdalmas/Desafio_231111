using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers;

[ApiController, Route("[controller]")]
public class RegisterCardController(Mapper mapper) : ControllerBase
{
	[Route("")]
	public CardModel Post([FromBody] CardModelRequest card, [FromHeader]Guid customerid)
	{
		var model = mapper.Map<CardModel>(card);
		model.CustomerId = customerid;

		return model;
	}
}

public class CardModelRequest
{
	[Required]
	public string Number { get; set; } = string.Empty;

	[Required, StringLength(4)]
	public string CVV { get; set; } = string.Empty;
}