using API.Controllers;
using API.Models;
namespace API.Services;

public interface IPaymentService
{
	/// <summary>
	/// Process Payment
	/// </summary>
	/// <param name="card">card request to be processed</param>
	/// <param name="customerId">customer Id</param>
	/// <returns>card model with token</returns>
	CardModel ProcessPayment(CardModelRequest card, Guid customerId);
}