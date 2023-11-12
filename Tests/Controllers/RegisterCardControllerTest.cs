using API.Configs;
using API.Controllers;
using API.Extensions;
using API.Models;
using API.Services;
using Microsoft.Extensions.Options;
using Moq;
using Tests.Models;
namespace Tests.Controllers;

public class RegisterCardControllerTest
{
	public static CardModelRequest CardModel => new() { Number = "1234.5678.9012.3456", CVV = "159" };

	[Fact]
	public void PostMoqService()
	{
		// Arrange
		var mockService = new Mock<IPaymentService>();
		mockService.Setup(service => service.ProcessPayment(It.IsAny<CardModelRequest>(), It.IsAny<Guid>()))
			.Returns(CardModelTest.CardModel);
		var controller = new RegisterCardController(mockService.Object);
		// Act
		var result = controller.Post(CardModel, Guid.NewGuid());
		// Assert
		Assert.IsType<CardModel>(result);
		Assert.Null(result.Token);
		Assert.Equal(result.CustomerId, Guid.Empty);
	}

	[Fact]
	public void PostProviderA()
	{
		// Arrange
		var mockOptions = new Mock<IOptions<ProviderOptions>>();
		mockOptions.Setup(options => options.Value).Returns(new ProviderOptions() { A = true, B = false });
		var controller = new RegisterCardController(new PaymentService(MapperConfig.InitializeAutomapper(), mockOptions.Object));
		// Act
		var result = controller.Post(CardModel, Guid.NewGuid());
		// Assert
		Assert.IsType<CardModel>(result);
		Assert.NotNull(result?.Token);
		Assert.NotEmpty(result.Token);
		Assert.Equal(result.Md5Hash(), result.Token);
		Assert.NotEqual(result.CustomerId, Guid.Empty);
	}

	[Fact]
	public void PostProviderB()
	{
		// Arrange
		var mockOptions = new Mock<IOptions<ProviderOptions>>();
		mockOptions.Setup(options => options.Value).Returns(new ProviderOptions() { A = false, B = true });
		var controller = new RegisterCardController(new PaymentService(MapperConfig.InitializeAutomapper(), mockOptions.Object));
		// Act
		var result = controller.Post(CardModel, Guid.NewGuid());
		// Assert
		Assert.IsType<CardModel>(result);
		Assert.NotNull(result?.Token);
		Assert.NotEmpty(result.Token);
		Assert.Equal(result.RightCircularRotation(), result.Token);
		Assert.NotEqual(result.CustomerId, Guid.Empty);
	}
}