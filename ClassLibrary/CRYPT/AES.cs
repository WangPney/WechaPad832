using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CRYPT
{
	public static class AES
	{
		private static UTF8Encoding encoding = new UTF8Encoding();

		public static byte[] AESDecrypt(byte[] data, byte[] password, CipherMode mode = CipherMode.CBC)
		{
			byte[] result;
			try
			{
				using (Aes aes = new AesManaged())
				{
					aes.Mode = mode;
					aes.Key = password;
					aes.IV = password;
					using (MemoryStream memoryStream = new MemoryStream())
					{
						using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
						{
							cryptoStream.Write(data, 0, data.Length);
							cryptoStream.FlushFinalBlock();
						}
						result = memoryStream.ToArray();
					}
				}
			}
			catch (Exception ex)
			{
				Debug.Print("aes encryption failed ", new object[]
				{
					ex
				});
				result = null;
			}
			return result;
		}

		private static string AESDoPadWithString(string ogiginalStr, int PadWindth)
		{
			char paddingChar = '0';
			bool flag = ogiginalStr.Length > PadWindth;
			string result;
			if (flag)
			{
				result = ogiginalStr.Remove(PadWindth);
			}
			else
			{
				bool flag2 = ogiginalStr.Length < PadWindth;
				if (flag2)
				{
					result = ogiginalStr.PadRight(PadWindth, paddingChar);
				}
				else
				{
					result = ogiginalStr;
				}
			}
			return result;
		}

		public static byte[] AESEncrypt(byte[] data, byte[] password, CipherMode mode = CipherMode.CBC)
		{
			byte[] result;
			try
			{
				using (Aes aes = new AesManaged())
				{
					aes.Mode = mode;
					aes.Key = password;
					aes.IV = password;
					using (MemoryStream memoryStream = new MemoryStream())
					{
						using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
						{
							cryptoStream.Write(data, 0, data.Length);
							cryptoStream.FlushFinalBlock();
						}
						result = memoryStream.ToArray();
					}
				}
			}
			catch (Exception ex)
			{
				Debug.Print("aes encryption failed ", new object[]
				{
					ex
				});
				result = null;
			}
			return result;
		}
	}
}
