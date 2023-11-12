using API.Configs;
using API.Models;
using Tests.Controllers;
namespace Tests.Configs;

public class MapperConfigTest
{
	[Fact]
	public void Request2CardModel()
	{
		// Arrange
		var mapper = MapperConfig.InitializeAutomapper();
		var request = RegisterCardControllerTest.CardModel;
		// Act
		var response = mapper.Map<CardModel>(request);
		// Assert
		Assert.NotEmpty(response.Number);
		Assert.NotEmpty(response.CVV);
		Assert.Null(response.Token);
		Assert.Equal(Guid.Empty, response.CustomerId);
	}
}