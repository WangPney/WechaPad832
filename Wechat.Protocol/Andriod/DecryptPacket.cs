using System;
using System.Linq;
using System.Security.Cryptography;

namespace Wechat.Protocol.Andriod
{
	public class DecryptPacket
	{
		public static byte[] DecryptReceivedPacket(byte[] receivedPacket, byte[] key)
		{
			byte[] result = null;
			try
			{
				AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
				aesCryptoServiceProvider.Key = key;
				aesCryptoServiceProvider.Mode = CipherMode.CBC;
				aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;
				aesCryptoServiceProvider.IV = key;
				ICryptoTransform cryptoTransform = aesCryptoServiceProvider.CreateDecryptor();
				result = cryptoTransform.TransformFinalBlock(receivedPacket, 0, receivedPacket.Length);
				aesCryptoServiceProvider.Clear();
			}
			catch (Exception)
			{
			}
			return result;
		}

		public static byte[] AESEncryptorData(byte[] data, byte[] key)
		{
			AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
			aesCryptoServiceProvider.Key = key.Take(16).ToArray();
			aesCryptoServiceProvider.Mode = CipherMode.CBC;
			aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;
			aesCryptoServiceProvider.IV = key.Take(16).ToArray();
			ICryptoTransform cryptoTransform = aesCryptoServiceProvider.CreateEncryptor();
			byte[] array = null;
			array = cryptoTransform.TransformFinalBlock(data, 0, data.Length);
			aesCryptoServiceProvider.Clear();
			return array;
		}
	}
}
