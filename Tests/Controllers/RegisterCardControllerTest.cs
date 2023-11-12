using API.Configs;
using API.Controllers;

namespace Tests.Models;

public class RegisterCardControllerTest
{
	public static CardModelRequest CardModel => new() { Number = "1234.5678.9012.3456", CVV = "159" };

	[Fact]
    public void Post()
    {
		// Arrange
        var controller = new RegisterCardController(MapperConfig.InitializeAutomapper());
		var card = CardModel;
		// Act
		var result = controller.Post(card, Guid.NewGuid());
		// Assert
		Assert.NotNull(result?.Token);
		Assert.NotEmpty(result.Token);
	}
}