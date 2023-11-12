using API.Models;
using System.Security.Cryptography;
using System.Text;
namespace API.Extensions;

public static class CardModelExtension
{
	public static string GetMd5Hash(this CardModel card)
	{
		var input = card.Number + card.CVV;

		using MD5 md5Hash = MD5.Create();
		byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

		StringBuilder sBuilder = new();
		for (int i = 0; i < data.Length; i++)
			sBuilder.Append(data[i].ToString("x2"));

		return sBuilder.ToString();
	}

	public static string RightCircularRotation(this CardModel card)
	{
		char[] input = card.Number[^4..].ToCharArray();

		var result = input.RightRotate(int.Parse(card.CVV));

		return string.Join("", result);
	}

	public static char[] RightRotate(this char[] arr, int rotations)
	{
		int length = arr.Length;
		char[] rotatedArray = new char[length];

		for (int i = 0; i < length; i++)
			rotatedArray[(i + rotations) % length] = arr[i];

		return rotatedArray;
	}
}