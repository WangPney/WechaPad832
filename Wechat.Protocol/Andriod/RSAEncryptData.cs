using System;
using System.Linq;
using System.Security.Cryptography;

namespace Wechat.Protocol.Andriod
{
	public class RSAEncryptData
	{
		private static string rsaKey = "D153E8A2B314D2110250A0A550DDACDCD77F5801F3D1CC21CB1B477E4F2DE8697D40F10265D066BE8200876BB7135EDC74CDBC7C4428064E0CDCBE1B6B92D93CEAD69EC27126DEBDE564AAE1519ACA836AA70487346C85931273E3AA9D24A721D0B854A7FCB9DED49EE03A44C189124FBEB8B17BB1DBE47A534637777D33EEC88802CD56D0C7683A796027474FEBF237FA5BF85C044ADC63885A70388CD3696D1F2E466EB6666EC8EFE1F91BC9353F8F0EAC67CC7B3281F819A17501E15D03291A2A189F6A35592130DE2FE5ED8E3ED59F65C488391E2D9557748D4065D00CBEA74EB8CA19867C65B3E57237BAA8BF0C0F79EBFC72E78AC29621C8AD61A2B79B";

		private static string rsaKeyNewReg = "D153E8A2B314D2110250A0A550DDACDCD77F5801F3D1CC21CB1B477E4F2DE8697D40F10265D066BE8200876BB7135EDC74CDBC7C4428064E0CDCBE1B6B92D93CEAD69EC27126DEBDE564AAE1519ACA836AA70487346C85931273E3AA9D24A721D0B854A7FCB9DED49EE03A44C189124FBEB8B17BB1DBE47A534637777D33EEC88802CD56D0C7683A796027474FEBF237FA5BF85C044ADC63885A70388CD3696D1F2E466EB6666EC8EFE1F91BC9353F8F0EAC67CC7B3281F819A17501E15D03291A2A189F6A35592130DE2FE5ED8E3ED59F65C488391E2D9557748D4065D00CBEA74EB8CA19867C65B3E57237BAA8BF0C0F79EBFC72E78AC29621C8AD61A2B79B";

		public static byte[] RSAEncryptCoreData(byte[] data)
		{
			byte[] array = null;
			if (data.Length <= 256)
			{
				byte[] inArray = strToToHexByte(rsaKey);
				string publickey = Convert.ToBase64String(inArray);
				return RSAEncrypt(publickey, data);
			}
			byte[] byt = data.Take(244).ToArray();
			byte[] byt2 = data.Take(data.Length).Skip(244).ToArray();
			byte[] inArray2 = strToToHexByte(rsaKey);
			string publickey2 = Convert.ToBase64String(inArray2);
			byte[] first = RSAEncrypt(publickey2, byt);
			byte[] second = RSAEncrypt(publickey2, byt2);
			return first.Concat(second).ToArray();
		}

		public static byte[] RSAEncryptNewReg(byte[] data)
		{
			byte[] array = new byte[0];
			byte[] inArray = strToToHexByte(rsaKeyNewReg);
			string publickey = Convert.ToBase64String(inArray);
			int count = 244;
			while (data.Length != 0)
			{
				byte[] array2 = data.Take(count).ToArray();
				byte[] second = RSAEncrypt(publickey, array2);
				array = array.Concat(second).ToArray();
				data = data.Skip(array2.Length).ToArray();
			}
			return array;
		}

		private static byte[] RSAEncrypt(string publickey, byte[] byt)
		{
			publickey = "<RSAKeyValue><Modulus>" + publickey + "</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
			RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
			rSACryptoServiceProvider.FromXmlString(publickey);
			return rSACryptoServiceProvider.Encrypt(byt, false);
		}

		private static byte[] strToToHexByte(string hexString)
		{
			hexString = hexString.Replace(" ", "");
			if (hexString.Length % 2 != 0)
			{
				hexString += " ";
			}
			byte[] array = new byte[hexString.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
			}
			return array;
		}
	}
}
