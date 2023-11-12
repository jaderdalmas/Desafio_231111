using API.Configs;
using API.Controllers;
using API.Models;
using API.Providers;
using AutoMapper;
using Microsoft.Extensions.Options;
namespace API.Services;

public class PaymentService(Mapper mapper, IOptions<ProviderOptions> options) : IPaymentService
{
	private readonly IPaymentProvider _paymentProvider = options.Value.A ? new PaymentProviderA() : new PaymentProviderB();

	public CardModel ProcessPayment(CardModelRequest card, Guid customerId)
	{
		var model = mapper.Map<CardModel>(card);
		model.CustomerId = customerId;

		_paymentProvider.ProcessCard(model);

		return model;
	}
}