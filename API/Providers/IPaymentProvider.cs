using API.Models;
namespace API.Providers;

public interface IPaymentProvider
{
	/// <summary>
	/// Process card
	/// </summary>
	/// <param name="card">card to be processed</param>
	/// <returns>token</returns>
	string ProcessCard(CardModel card);
}