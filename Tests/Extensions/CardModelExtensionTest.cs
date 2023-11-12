using API.Extensions;
using Tests.Models;
namespace Tests.Extensions;

public class CardModelExtensionTest
{
	[Fact]
	public void GetMd5Hash()
	{
		// Arrange
		var item = CardModelTest.CardModel;
		// Act
		item.Token = item.Md5Hash();
		// Assert
		Assert.Equal("218c367aaa0b1cf018e67ac9a20cd98f", item.Token);
	}

	[Fact]
	public void RightCircularRotation()
	{
		// Arrange
		var item = CardModelTest.CardModel;
		// Act
		item.Token = item.RightCircularRotation();
		// Assert
		Assert.Equal("4563", item.Token);
	}
}