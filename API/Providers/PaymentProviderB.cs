using API.Extensions;
using API.Models;
namespace API.Providers;

public class PaymentProviderB : IPaymentProvider
{
	public string ProcessCard(CardModel card)
	{
		card.Token = card.RightCircularRotation();

		return card.Token;
	}
}