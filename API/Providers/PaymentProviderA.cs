using API.Extensions;
using API.Models;
namespace API.Providers;

public class PaymentProviderA : IPaymentProvider
{
	public string ProcessCard(CardModel card)
	{
		card.Token = card.Md5Hash();

		return card.Token;
	}
}