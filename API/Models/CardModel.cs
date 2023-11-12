using System.ComponentModel.DataAnnotations;
namespace API.Models;

public class CardModel
{
	[Required]
	public string Number { get; set; } = string.Empty;

	[Required, StringLength(4)]
	public string CVV { get; set; } = string.Empty;

	public string? Token { get; set; }

	[Required]
	public Guid CustomerId { get; set; }
}
