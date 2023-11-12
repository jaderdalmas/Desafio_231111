using API.Models;
namespace Tests.Models;

public class CardModelTest
{
    [Fact]
    public void NewModel()
    {
		// Arrange
        var item = new CardModel();
		// Assert
		Assert.Empty(item.Number);
		Assert.Empty(item.CVV);
		Assert.Null(item.Token);
	}

	[Fact]
	public void FilledModel()
	{
		// Arrange
		var item = new CardModel
		{ // Act
			Number = "test",
			CVV = "test",
			Token = "test"
		};
		// Assert
		Assert.NotEmpty(item.Number);
		Assert.NotEmpty(item.CVV);
		Assert.NotEmpty(item.Token);
	}
}