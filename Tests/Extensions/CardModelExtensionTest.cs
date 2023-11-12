using API.Extensions;
using API.Models;
namespace Tests.Models;

public class CardModelExtensionTest
{
	[Fact]
	public void GetMd5Hash()
	{
		// Arrange
		var item = new CardModel { Number = "1234.5678.9012.3456", CVV = "159" };
		// Act
		item.Token = item.GetMd5Hash();
		// Assert
		Assert.Equal("218c367aaa0b1cf018e67ac9a20cd98f", item.Token);
	}

	[Fact]
	public void RightCircularRotation()
	{
		// Arrange
		var item = new CardModel { Number = "1234.5678.9012.3456", CVV = "159" };
		// Act
		item.Token = item.RightCircularRotation();
		// Assert
		Assert.Equal("4563", item.Token);
	}
}